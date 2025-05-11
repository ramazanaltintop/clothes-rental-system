using ClothesRentalSystem.Entity;

namespace ClothesRentalSystem.Service.Abstract;

public interface IRentService
{
    void AddToCart(byte day, byte quantity, string clothingItemName);

    List<Rent> GetListByUsername(string username);
    List<Rent> GetListByApproved();
    List<Rent> GetListByPending();
    List<Rent> GetListByRejected();
    List<Rent> GetListByApprovedOrRejected();
    List<Rent> GetListByPendingAll();
    List<Rent> GetListByAdminDecision();
    Rent GetById(long id);
    Rent GetByFicheName(string ficheName);
    List<CartItem> GetCart();
    decimal GetTotalEarnings();
    long GetTotalSales();

    void SendRequest();
    void ApproveRequest(string ficheName);
    void RejectRequest(string ficheName);

    void ClearCart();
}
