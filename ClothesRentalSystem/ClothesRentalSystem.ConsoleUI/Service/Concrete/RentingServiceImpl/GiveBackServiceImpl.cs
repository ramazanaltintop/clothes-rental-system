using ClothesRentalSystem.ConsoleUI.Entity.Enum;
using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Repository.RentingRepository;
using ClothesRentalSystem.ConsoleUI.Exception.AuthException;
using ClothesRentalSystem.ConsoleUI.Exception.GiveBackException;

namespace ClothesRentalSystem.ConsoleUI.Service.Concrete.RentingServiceImpl;

public class GiveBackServiceImpl : IGiveBackService
{
    private readonly GiveBackRepository _repository;
    private readonly IUserService _userService;
    private readonly IAdminService _adminService;
    private readonly IClothesService _clothesService;
    private readonly IRentService _rentService;

    public GiveBackServiceImpl(GiveBackRepository repository, IUserService userService, IAdminService adminService, IClothesService clothesService, IRentService rentService)
    {
        _repository = repository;
        _userService = userService;
        _adminService = adminService;
        _clothesService = clothesService;
        _rentService = rentService;
    }

    // Iade Talebinin Olusturulmasi
    public bool SendRequest(long rentId, long peopleId)
    {
        // iade talebinde bulunacak olan kullanıcı
        // sistemde var mı
        User user = _userService.GetById(peopleId);

        // kullanıcının rolü doğru rol mü
        if (user.Auth.Role != ERole.USER)
            throw new UserOnlyAccessException();

        // iade talebi oluşturulan kıyafet sistemde var mı
        Rent rent = _rentService.GetById(rentId);

        // sadece kabul edilen kiralama talepleri
        // için iade talebi oluşturulabilir
        if (rent.IsApproved != ECondition.APPROVED)
            throw new GiveBackRequestNotAllowedException();

        // zaten iade talebinde bulunuldu mu
        if (rent.GiveBack == ECondition.REQUESTED)
            throw new GiveBackRequestAlreadySentException();

        rent.GiveBack = ECondition.REQUESTED;

        return _repository.SendRequest(rent);
    }

    // Iade Talebinin Kabul Edilmesi
    public bool ApproveRequest(long rentId, long peopleId)
    {
        // iade etme işlemini onaylayacak kullanıcı sistemde var mı
        Admin admin = _adminService.GetById(peopleId);

        // kullanıcının rolü doğru mu
        if (admin.Auth.Role != ERole.ADMIN)
            throw new AdminOnlyAccessException();

        // kiralanmak istenen böyle bir kıyafet var mı
        Rent rent = _rentService.GetById(rentId);

        // iade talebi zaten kabul edildi mi
        if (rent.GiveBack == ECondition.APPROVED)
            throw new GiveBackRequestAlreadyApprovedException();

        rent.GiveBack = ECondition.APPROVED;

        Clothes clothes = _clothesService.GetById(rent.Clothes.Id);
        clothes.StockCount += rent.Quantity;
        clothes.RentedCount -= rent.Quantity;

        return _repository.ApproveRequest(rent);
    }

    // Iade Talebinin Reddedilmesi
    public bool RejectRequest(long rentId, long peopleId)
    {
        // iade etme işlemini reddedecek kullanıcı sistemde var mı
        Admin admin = _adminService.GetById(peopleId);

        // kullanıcının rolü doğru mu
        if (admin.Auth.Role != ERole.ADMIN)
            throw new AdminOnlyAccessException();

        // kiralanmak istenen böyle bir kıyafet var mı
        Rent rent = _rentService.GetById(rentId);

        // iade talebi zaten reddedildi mi
        if (rent.GiveBack == ECondition.REJECTED)
            throw new GiveBackRequestAlreadyRejectedException();

        rent.GiveBack = ECondition.REJECTED;

        // kiralanan kiyafet hasar gordugu icin iade kabul edilmedi
        // urunler kabul edilmeyecegi icin stok miktarindaki
        // azalis duzelmez.
        // sadece kiralik gorunen urun sayisinda dusus olacaktir.
        Clothes clothes = _clothesService.GetById(rent.Clothes.Id);
        clothes.RentedCount -= rent.Quantity;

        return _repository.RejectRequest(rent);
    }

    // Onaylanan Iade Istekleri
    public List<Rent> GetListByApproved(long peopleId)
    {
        // sadece user rolüne sahip kullanıcılar
        // kendi onaylanmış kiralama isteklerini
        // listeleme ihtiyacı duyabilir.

        // böyle bir user sistemde kayıtlı mı
        User user = _userService.GetById(peopleId);

        // kullanıcının rolü yetkili mi
        if (user.Auth.Role != ERole.USER)
            throw new UserOnlyAccessException();

        List<Rent> rentals = _repository.GetListByApproved(peopleId);

        if (rentals.Count == 0)
            throw new NoApprovedGiveBackRequestsException();

        return rentals;
    }

    // Iade İstekleri
    public List<Rent> GetListByPending(long peopleId)
    {
        // sadece user rolüne sahip kullanıcılar
        // kendi kiralama isteklerini listeleyebilir

        // böyle bir user sistemde kayıtlı mı
        User user = _userService.GetById(peopleId);

        // kullanıcının rolü yetkili mi
        if (user.Auth.Role != ERole.USER)
            throw new UserOnlyAccessException();

        List<Rent> rentals = _repository.GetListByPending(peopleId);

        if (rentals.Count == 0)
            throw new NoPendingGiveBackRequestsException();

        return rentals;
    }

    // Reddedilen Iade Istekleri
    public List<Rent> GetListByRejected(long peopleId)
    {
        // sadece user rolüne sahip kullanıcılar
        // reddedilen kendi kiralama isteklerini listeleyebilir

        // böyle bir user sistemde kayıtlı mı
        User user = _userService.GetById(peopleId);

        // kullanıcının rolü yetkili mi
        if (user.Auth.Role != ERole.USER)
            throw new UserOnlyAccessException();

        List<Rent> rentals = _repository.GetListByRejected(peopleId);

        if (rentals.Count == 0)
            throw new NoRejectedGiveBackRequestsException();

        return rentals;
    }

    // Gecmis Iade İstekleri
    public List<Rent> GetListByApprovedOrRejected(long peopleId)
    {
        // sadece user rolüne sahip kullanıcılar
        // kendi geçmiş kiralama isteklerini görebilir.

        // böyle bir user sistemde kayıtlı mı
        User user = _userService.GetById(peopleId);

        // kullanıcının rolü yetkili mi
        if (user.Auth.Role != ERole.USER)
            throw new UserOnlyAccessException();

        List<Rent> rentals = _repository.GetListByApprovedOrRejected(peopleId);

        if (rentals.Count == 0)
            throw new NoGiveBackHistoryFoundException();

        return rentals;
    }

    public List<Rent> GetListByUsername(string username, long peopleId)
    {
        // herhangi bir kullanıcının geçmiş iade isteklerini
        // görüntülemek isteyen kullanıcı sistemde kayıtlı bir
        // kullanıcı mı?
        Admin admin = _adminService.GetById(peopleId);

        // Kullanıcı sistemde varsa rolü uygun mu?
        if (admin.Auth.Role != ERole.ADMIN)
            throw new AdminOnlyAccessException();

        // Geçmiş iade isteklerini görmek istediğimiz
        // kullanıcı sistemde kayıtlı bir kullanıcı mı?
        User user = _userService.GetByUsername(username);

        return _repository.GetListByUsername(username);
    }

    public List<Rent> GetListByPendingAll(long peopleId)
    {
        // Bu işlemi yapmak isteyen kullanıcı sistemde kayıtlı mı
        Admin admin = _adminService.GetById(peopleId);

        // Kullanıcı admin rolüne sahip mi
        if (admin.Auth.Role != ERole.ADMIN)
            throw new AdminOnlyAccessException();

        return _repository.GetListByPendingAll();
    }
}
