using ClothesRentalSystem.Entity;

namespace ClothesRentalSystem.Service.Abstract;

public interface IReturnService
{
    List<Rent> GetListByUsername(string username);
    List<Rent> GetListByApproved();
    List<Rent> GetListByPending();
    List<Rent> GetListByRejected();
    List<Rent> GetListByApprovedOrRejected();
    List<Rent> GetListByPendingAll();
    List<Rent> GetListByAdminDecision();

    void SendRequest(string ficheName);
    void ApproveRequest(string ficheName);
    void RejectRequest(string ficheName);
}
