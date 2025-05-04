using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Service.Concrete;

namespace ClothesRentalSystem.ConsoleUI.Presentation;

public class GiveBackController
{
    private readonly IGiveBackService _giveBackService;

    public GiveBackController()
    {
        _giveBackService = new GiveBackServiceImpl(
            new GiveBackRepository(),
            new UserServiceImpl(new UserRepository()),
            new AdminServiceImpl(new AdminRepository(),
                new UserServiceImpl(new UserRepository())),
            new ClothesServiceImpl(new ClothesRepository(),
                new CategoryServiceImpl(new CategoryRepository(),
                    new AdminServiceImpl(new AdminRepository(),
                        new UserServiceImpl(new UserRepository()))),
                new AdminServiceImpl(new AdminRepository(),
                    new UserServiceImpl(new UserRepository()))),
            new RentServiceImpl(new RentRepository(),
                new UserServiceImpl(new UserRepository()),
                new ClothesServiceImpl(new ClothesRepository(),
                    new CategoryServiceImpl(new CategoryRepository(),
                        new AdminServiceImpl(new AdminRepository(),
                            new UserServiceImpl(new UserRepository()))),
                    new AdminServiceImpl(new AdminRepository(),
                        new UserServiceImpl(new UserRepository()))),
                new AdminServiceImpl(new AdminRepository(),
                    new UserServiceImpl(new UserRepository()))));
    }

    public List<Rent> GetListByUsername(string username)
    {
        return _giveBackService.GetListByUsername(username);
    }

    public List<Rent> GetListByApproved()
    {
        return _giveBackService.GetListByApproved();
    }

    public List<Rent> GetListByPending()
    {
        return _giveBackService.GetListByPending();
    }

    public List<Rent> GetListByRejected()
    {
        return _giveBackService.GetListByRejected();
    }

    public List<Rent> GetListByApprovedOrRejected()
    {
        return _giveBackService.GetListByApprovedOrRejected();
    }

    public List<Rent> GetListByPendingAll()
    {
        return _giveBackService.GetListByPendingAll();
    }

    public List<Rent> GetListByAdminDecision()
    {
        return _giveBackService.GetListByAdminDecision();
    }

    public void SendRequest(long rentId)
    {
        _giveBackService.SendRequest(rentId);
    }

    public void ApproveRequest(long rentId)
    {
        _giveBackService.ApproveRequest(rentId);
    }

    public void RejectRequest(long rentId)
    {
        _giveBackService.RejectRequest(rentId);
    }
}
