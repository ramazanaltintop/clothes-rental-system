using ClothesRentalSystem.ConsoleUI.Entity;

namespace ClothesRentalSystem.ConsoleUI.Service.Abstract;

public interface IRentService
{
    void AddToCart(byte day, byte quantity, string clothesName);

    List<Rent> GetListByUsername(string username);
    List<Rent> GetListByApproved();
    List<Rent> GetListByPending();
    List<Rent> GetListByRejected();
    List<Rent> GetListByApprovedOrRejected();
    List<Rent> GetListByPendingAll();
    List<Rent> GetListByAdminDecision();
    Rent GetById(long id);
    List<CartItem> GetCart();
    decimal GetTotalEarnings();
    long GetTotalSales();

    void SendRequest();
    void ApproveRequest(long id);
    void RejectRequest(long id);
}
