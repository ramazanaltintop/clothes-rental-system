using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Repository.RentingRepository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Service.Concrete;
using ClothesRentalSystem.ConsoleUI.Service.Concrete.RentingServiceImpl;

namespace ClothesRentalSystem.ConsoleUI.Presentation.RentingController;

public class RentController
{
    private readonly IRentService _rentService;

    public RentController()
    {
        _rentService = new RentServiceImpl(
            new RentRepository(),
            new UserServiceImpl(new UserRepository()),
            new ClothesServiceImpl(new ClothesRepository(),
                new CategoryServiceImpl(new CategoryRepository()),
                new AdminServiceImpl(new AdminRepository()
                , new UserServiceImpl(new UserRepository()))),
            new AdminServiceImpl(new AdminRepository()
            , new UserServiceImpl(new UserRepository())));
    }
    // Toplam Kazanç
    public decimal GetTotalEarnings()
    {
        return _rentService.GetTotalEarnings();
    }

    // Kiralama Talebinin Oluşturulması
    public void SendRequest(byte day, byte quantity, long clothesId, long peopleId)
    {
        _rentService.SendRequest(day, quantity, clothesId, peopleId);
    }

    // Kiralama Talebinin Kabul Edilmesi
    public bool ApproveRequest(long id, long peopleId)
    {
        return _rentService.ApproveRequest(id, peopleId);
    }

    // Kiralama Talebinin Reddedilmesi
    public bool RejectRequest(long id, long peopleId)
    {
        return _rentService.RejectRequest(id, peopleId);
    }

    public Rent GetById(long id)
    {
        return _rentService.GetById(id);
    }

    // Onaylanan Kiralama İstekleri
    public List<Rent> GetListByApproved(long peopleId)
    {
        return _rentService.GetListByApproved(peopleId);
    }

    // Kiralama İstekleri
    public List<Rent> GetListByPending(long peopleId)
    {
        return _rentService.GetListByPending(peopleId);
    }

    // Reddedilen Kiralama İstekleri
    public List<Rent> GetListByRejected(long peopleId)
    {
        return _rentService.GetListByRejected(peopleId);
    }

    // Geçmiş Kiralama İstekleri
    public List<Rent> GetListByApprovedOrRejected(long peopleId)
    {
        return _rentService.GetListByApprovedOrRejected(peopleId);
    }

    // Herhangi bir kullanıcının Geçmiş Kiralama İstekleri
    public List<Rent> GetListByUsername(string username, long peopleId)
    {
        return _rentService.GetListByUsername(username, peopleId);
    }

    // Tüm kullanıcıların bekleyen kiralama istekleri
    public List<Rent> GetListByPendingAll(long peopleId)
    {
        return _rentService.GetListByPendingAll(peopleId);
    }
}
