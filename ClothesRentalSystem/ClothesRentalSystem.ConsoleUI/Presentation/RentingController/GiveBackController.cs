using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Repository.RentingRepository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Service.Concrete;
using ClothesRentalSystem.ConsoleUI.Service.Concrete.RentingServiceImpl;

namespace ClothesRentalSystem.ConsoleUI.Presentation.RentingController;

public class GiveBackController
{
    private readonly IGiveBackService _giveBackService;

    public GiveBackController()
    {
        _giveBackService = new GiveBackServiceImpl(
            new GiveBackRepository(),
            new UserServiceImpl(new UserRepository()),
            new AdminServiceImpl(new AdminRepository()),
            new ClothesServiceImpl(new ClothesRepository(),
                new CategoryServiceImpl(new CategoryRepository()),
                new AdminServiceImpl(new AdminRepository())),
            new RentServiceImpl(new RentRepository(),
                new UserServiceImpl(new UserRepository()),
                new ClothesServiceImpl(
                    new ClothesRepository(),
                    new CategoryServiceImpl(new CategoryRepository()),
                    new AdminServiceImpl(new AdminRepository())),
                new AdminServiceImpl(new AdminRepository())));
    }

    // İade Talebinin Oluşturulması
    public bool SendRequest(long rentId, long peopleId)
    {
        return _giveBackService.SendRequest(rentId, peopleId);
    }

    // İade Talebinin Kabul Edilmesi
    public bool ApproveRequest(long rentId, long peopleId)
    {
        return _giveBackService.ApproveRequest(rentId, peopleId);
    }

    // İade Talebinin Reddedilmesi
    public bool RejectRequest(long rentId, long peopleId)
    {
        return _giveBackService.RejectRequest(rentId, peopleId);
    }

    // Onaylanan Iade İstekleri
    public List<Rent> GetListByApproved(long peopleId)
    {
        return _giveBackService.GetListByApproved(peopleId);
    }

    // Iade İstekleri
    public List<Rent> GetListByRequested(long peopleId)
    {
        return _giveBackService.GetListByRequested(peopleId);
    }

    // Reddedilen Iade İstekleri
    public List<Rent> GetListByRejected(long peopleId)
    {
        return _giveBackService.GetListByRejected(peopleId);
    }

    // Gecmis Iade İstekleri
    public List<Rent> GetListByApprovedOrRejected(long peopleId)
    {
        return _giveBackService.GetListByApprovedOrRejected(peopleId);
    }

    // Herhangi bir kullanıcının Geçmiş Iade İstekleri
    public List<Rent> GetListByUsername(string username, long peopleId)
    {
        return _giveBackService.GetListByUsername(username, peopleId);
    }

    // Tüm kullanıcıların bekleyen iade istekleri
    public List<Rent> GetListByRequestedAll(long peopleId)
    {
        return _giveBackService.GetListByRequestedAll(peopleId);
    }
}
