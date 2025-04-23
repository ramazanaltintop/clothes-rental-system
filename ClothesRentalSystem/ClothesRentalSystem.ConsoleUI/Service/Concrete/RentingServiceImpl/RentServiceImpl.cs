using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Entity.Enum;
using ClothesRentalSystem.ConsoleUI.Repository.RentingRepository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Util;

namespace ClothesRentalSystem.ConsoleUI.Service.Concrete.RentingServiceImpl;

public class RentServiceImpl : IRentService
{
    private readonly RentRepository _repository;
    private readonly IUserService _userService;
    private readonly IClothesService _clothesService;
    private readonly IAdminService _adminService;

    public RentServiceImpl(RentRepository repository, IUserService userService, IClothesService clothesService, IAdminService adminService)
    {
        _repository = repository;
        _userService = userService;
        _clothesService = clothesService;
        _adminService = adminService;
    }

    // Kiralama Talebinin Oluşturulması
    public void SendRequest(byte day, byte quantity, long clothesId, long peopleId)
    {
        // kiralama talebinde bulunan kullanıcı sistemde var mı
        User user = _userService.GetById(peopleId);

        // Sadece USER rolüne sahipse kiralama talebinde bulunabilir
        if (user.Auth.Role != ERole.USER)
            throw new Exception("You are not authorized");

        // kiralanacak kıyafet var mı
        Clothes clothes = _clothesService.GetById(clothesId);

        // kıyafetin stok adedi yeterli mi
        if (clothes.StockCount - quantity < 0)
            throw new Exception("Clothes stock is finished");

        // nesne oluşturduk
        Rent rent = new Rent();
        rent.Id = GenerateId.GenerateRentId();
        rent.Day = day;
        rent.User = user;
        rent.Quantity = quantity;
        rent.Clothes = clothes;
        rent.TotalPrice = quantity * rent.Day * clothes.Price;

        rent.IsApproved = ECondition.REQUESTED;

        _repository.SendRequest(rent);
    }

    // Kiralama Talebinin Kabul Edilmesi
    public bool ApproveRequest(long id, long peopleId)
    {
        // onayı verilmek istenen kıyafet için
        // kullanıcı kiralama talebinde bulunmuş mu
        Rent rent = GetById(id);

        // isteği kabul edecek böyle bir admin var mı
        Admin admin = _adminService.GetById(peopleId);

        // kullanıcının rolü doğru mu
        if (admin.Auth.Role != ERole.ADMIN)
            throw new Exception("You are not authorized");

        // zaten kiralama talebi onaylandı mı
        if (rent.IsApproved == ECondition.APPROVED)
            throw new Exception("Rent request already approved.");

        // kiralama talebi onaylandı
        rent.IsApproved = ECondition.APPROVED;

        // stok miktarı güncelle
        Clothes cl = _clothesService.GetById(rent.Clothes.Id);
        cl.StockCount -= rent.Quantity;
        cl.RentedCount += rent.Quantity;

        return _repository.ApproveRequest(rent);
    }

    // Kiralama Talebinin Reddedilmesi
    public bool RejectRequest(long id, long peopleId)
    {
        // reddedilmek istenen kıyafet için
        // kullanıcı kiralama talebinde bulunmuş mu
        Rent rent = GetById(id);

        // isteği reddedecek böyle bir admin var mı
        Admin admin = _adminService.GetById(peopleId);

        // kullanıcının rolü doğru mu
        if (admin.Auth.Role != ERole.ADMIN)
            throw new Exception("You are not authorized");

        // zaten kiralama talebi reddedildi mi
        if (rent.IsApproved == ECondition.REJECTED)
            throw new Exception("Rent request already rejected.");

        // kiralama talebi reddedildi
        rent.IsApproved = ECondition.REJECTED;

        return _repository.RejectRequest(rent);
    }

    // Id Bilgisine Gore Kiralanan Kiyafetin Getirilmesi
    public Rent GetById(long id)
    {
        return _repository.GetById(id)
            ?? throw new Exception("Rented clothes not found");
    }

    // Onaylanan Kiralama İstekleri
    public List<Rent> GetListByApproved(long peopleId)
    {
        // sadece user rolüne sahip kullanıcılar
        // kendi onaylanmış kiralama isteklerini
        // listeleme ihtiyacı duyabilir.

        // böyle bir admin sistemde kayıtlı mı
        User user = _userService.GetById(peopleId);

        // kullanıcının rolü yetkili mi
        if (user.Auth.Role != ERole.USER)
            throw new Exception("You are not authorized");

        return _repository.GetListByApproved(peopleId);
    }

    // Kiralama İstekleri
    public List<Rent> GetListByRequested(long peopleId)
    {
        // sadece user rolüne sahip kullanıcılar
        // kendi kiralama isteklerini
        // listeleme ihtiyacı duyabilir.

        // böyle bir user sistemde kayıtlı mı
        User user = _userService.GetById(peopleId);

        // kullanıcının rolü yetkili mi
        if (user.Auth.Role != ERole.USER)
            throw new Exception("You are not authorized");

        return _repository.GetListByRequested(peopleId);
    }

    // Reddedilen Kiralama İstekleri
    public List<Rent> GetListByRejected(long peopleId)
    {
        // sadece user rolüne sahip kullanıcılar
        // reddedilen kendi kiralama isteklerini listeleyebilir

        // böyle bir user sistemde kayıtlı mı
        User user = _userService.GetById(peopleId);

        // kullanıcının rolü yetkili mi
        if (user.Auth.Role != ERole.USER)
            throw new Exception("You are not authorized");

        return _repository.GetListByRejected(peopleId);
    }

    // Geçmiş Kiralama İstekleri
    public List<Rent> GetListByApprovedOrRejected(long peopleId)
    {
        // sadece user rolüne sahip kullanıcılar
        // kendi geçmiş kiralama isteklerini görebilir.

        // böyle bir user sistemde kayıtlı mı
        User user = _userService.GetById(peopleId);

        // kullanıcının rolü yetkili mi
        if (user.Auth.Role != ERole.USER)
            throw new Exception("You are not authorized");

        return _repository.GetListByApprovedOrRejected(peopleId);
    }

    // Herhangi bir kullanıcının Geçmiş Kiralama İstekleri
    public List<Rent> GetListByUsername(string username, long peopleId)
    {
        // herhangi bir kullanıcının geçmiş kiralama isteklerini
        // görüntülemek isteyen kullanıcı sistemde kayıtlı bir
        // kullanıcı mı?
        Admin admin = _adminService.GetById(peopleId);

        // Kullanıcı sistemde varsa rolü uygun mu?
        if (admin.Auth.Role != ERole.ADMIN)
            throw new Exception("You are not authorized");

        // Geçmiş kiralama isteklerini görmek istediğimiz
        // kullanıcı sistemde kayıtlı bir kullanıcı mı?
        User user = _userService.GetByUsername(username);

        return _repository.GetListByUsername(username);
    }

    // Tüm kullanıcıların bekleyen kiralama istekleri
    public List<Rent> GetListByRequestedAll(long peopleId)
    {
        // Bu işlemi yapmak isteyen kullanıcı sistemde kayıtlı mı
        Admin admin = _adminService.GetById(peopleId);

        // Kullanıcı admin rolüne sahip mi
        if (admin.Auth.Role != ERole.ADMIN)
            throw new Exception("You are not authorized");

        return _repository.GetListByRequestedAll();
    }
}
