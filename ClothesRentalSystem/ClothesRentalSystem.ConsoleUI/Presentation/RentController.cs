using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Service.Concrete;

namespace ClothesRentalSystem.ConsoleUI.Presentation;

public class RentController
{
    private readonly IRentService _rentService;

    public RentController()
    {
        _rentService = new RentServiceImpl(
            new RentRepository(),
            new UserServiceImpl(new UserRepository()),
            new ClothingItemServiceImpl(new ClothingItemRepository(),
                new CategoryServiceImpl(new CategoryRepository(),
                    new AdminServiceImpl(new AdminRepository(),
                        new UserServiceImpl(new UserRepository()))),
                new AdminServiceImpl(new AdminRepository()
                , new UserServiceImpl(new UserRepository()))),
            new AdminServiceImpl(new AdminRepository()
            , new UserServiceImpl(new UserRepository())));
    }

    public void AddToCart(byte day, byte quantity, string clothingItemName)
    {
        _rentService.AddToCart(day, quantity, clothingItemName);
    }

    public List<Rent> GetListByUsername(string username)
    {
        return _rentService.GetListByUsername(username);
    }

    public List<Rent> GetListByApproved()
    {
        return _rentService.GetListByApproved();
    }

    public List<Rent> GetListByPending()
    {
        return _rentService.GetListByPending();
    }

    public List<Rent> GetListByRejected()
    {
        return _rentService.GetListByRejected();
    }

    public List<Rent> GetListByApprovedOrRejected()
    {
        return _rentService.GetListByApprovedOrRejected();
    }

    public List<Rent> GetListByPendingAll()
    {
        return _rentService.GetListByPendingAll();
    }

    public List<Rent> GetListByAdminDecision()
    {
        return _rentService.GetListByAdminDecision();
    }

    public List<CartItem> GetCart()
    {
        return _rentService.GetCart();
    }

    public decimal GetTotalEarnings() => _rentService.GetTotalEarnings();

    public long GetTotalSales() => _rentService.GetTotalSales();


    public void SendRequest()
    {
        _rentService.SendRequest();
    }

    public void ApproveRequest(long id)
    {
        _rentService.ApproveRequest(id);
    }

    public void RejectRequest(long id)
    {
        _rentService.RejectRequest(id);
    }

    public void ClearCart()
    {
        _rentService.ClearCart();
    }
}
