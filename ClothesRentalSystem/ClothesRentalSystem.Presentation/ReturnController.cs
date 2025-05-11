using ClothesRentalSystem.Entity;
using ClothesRentalSystem.Repository;
using ClothesRentalSystem.Service.Abstract;
using ClothesRentalSystem.Service.Concrete;

namespace ClothesRentalSystem.Presentation;

public class ReturnController
{
    private readonly IReturnService _returnService;

    public ReturnController()
    {
        _returnService = new ReturnServiceImpl(
            new ReturnRepository(),
            new UserServiceImpl(new UserRepository()),
            new ClothingItemServiceImpl(new ClothingItemRepository(),
                new CategoryServiceImpl(new CategoryRepository(),
                    new UserServiceImpl(new UserRepository())),
                new UserServiceImpl(new UserRepository())),
            new RentServiceImpl(new RentRepository(),
                new UserServiceImpl(new UserRepository()),
                new ClothingItemServiceImpl(new ClothingItemRepository(),
                    new CategoryServiceImpl(new CategoryRepository(),
                        new UserServiceImpl(new UserRepository())),
                    new UserServiceImpl(new UserRepository()))));
    }

    public List<Rent> GetListByUsername(string username)
    {
        return _returnService.GetListByUsername(username);
    }

    public List<Rent> GetListByApproved()
    {
        return _returnService.GetListByApproved();
    }

    public List<Rent> GetListByPending()
    {
        return _returnService.GetListByPending();
    }

    public List<Rent> GetListByRejected()
    {
        return _returnService.GetListByRejected();
    }

    public List<Rent> GetListByApprovedOrRejected()
    {
        return _returnService.GetListByApprovedOrRejected();
    }

    public List<Rent> GetListByPendingAll()
    {
        return _returnService.GetListByPendingAll();
    }

    public List<Rent> GetListByAdminDecision()
    {
        return _returnService.GetListByAdminDecision();
    }

    public void SendRequest(string ficheName)
    {
        _returnService.SendRequest(ficheName);
    }

    public void ApproveRequest(string ficheName)
    {
        _returnService.ApproveRequest(ficheName);
    }

    public void RejectRequest(string ficheName)
    {
        _returnService.RejectRequest(ficheName);
    }
}
