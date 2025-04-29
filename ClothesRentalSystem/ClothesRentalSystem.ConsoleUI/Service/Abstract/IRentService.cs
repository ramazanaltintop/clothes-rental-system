using ClothesRentalSystem.ConsoleUI.Entity;

namespace ClothesRentalSystem.ConsoleUI.Service.Abstract;

public interface IRentService
{
    decimal GetTotalEarnings();
    void SendRequest(byte day, byte quantity, long clothesId, long peopleId);
    bool ApproveRequest(long id, long peopleId);
    bool RejectRequest(long id, long peopleId);
    Rent GetById(long id);
    List<Rent> GetListByApproved(long peopleId);
    List<Rent> GetListByPending(long peopleId);
    List<Rent> GetListByRejected(long peopleId);
    List<Rent> GetListByApprovedOrRejected(long peopleId);
    List<Rent> GetListByUsername(string username, long peopleId);
    List<Rent> GetListByPendingAll(long peopleId);
}
