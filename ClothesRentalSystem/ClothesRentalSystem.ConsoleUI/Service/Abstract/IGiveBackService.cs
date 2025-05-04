using ClothesRentalSystem.ConsoleUI.Entity;

namespace ClothesRentalSystem.ConsoleUI.Service.Abstract;

public interface IGiveBackService
{
    List<Rent> GetListByUsername(string username);
    List<Rent> GetListByApproved();
    List<Rent> GetListByPending();
    List<Rent> GetListByRejected();
    List<Rent> GetListByApprovedOrRejected();
    List<Rent> GetListByPendingAll();
    List<Rent> GetListByAdminDecision();

    void SendRequest(long id);
    void ApproveRequest(long id);
    void RejectRequest(long id);
}
