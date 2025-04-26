using ClothesRentalSystem.ConsoleUI.Entity;

namespace ClothesRentalSystem.ConsoleUI.Service.Abstract;

public interface IGiveBackService
{
    bool SendRequest(long id, long peopleId);
    bool ApproveRequest(long id, long peopleId);
    bool RejectRequest(long id, long peopleId);
    List<Rent> GetListByApproved(long peopleId);
    List<Rent> GetListByRequested(long peopleId);
    List<Rent> GetListByRejected(long peopleId);
    List<Rent> GetListByApprovedOrRejected(long peopleId);
    List<Rent> GetListByUsername(string username, long peopleId);
    List<Rent> GetListByRequestedAll(long peopleId);
}
