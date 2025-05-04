using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Entity.Enum;

namespace ClothesRentalSystem.ConsoleUI.Repository;

public class GiveBackRepository : List
{
    public List<Rent> GetListByUsername(string username)
    {
        return Rents.Where(rent => 
                rent.User.Auth.Username.Equals(username) &&
                rent.GiveBack != ECondition.FALSE)
            .ToList();
    }

    public List<Rent> GetListByApproved(long personId)
    {
        return Rents
            .Where(rent =>
                rent.User.Id == personId &&
                rent.GiveBack == ECondition.APPROVED)
            .ToList();
    }

    public List<Rent> GetListByPending(long personId)
    {
        return Rents
            .Where(rent =>
                rent.User.Id == personId &&
                rent.GiveBack == ECondition.REQUESTED)
            .ToList();
    }

    public List<Rent> GetListByRejected(long personId)
    {
        return Rents
            .Where(rent =>
                rent.User.Id == personId &&
                rent.GiveBack == ECondition.REJECTED)
            .ToList();
    }

    public List<Rent> GetListByApprovedOrRejected(long personId)
    {
        return Rents.Where(rent =>
            rent.User.Id == personId &&
            (rent.GiveBack == ECondition.APPROVED ||
            rent.GiveBack == ECondition.REJECTED))
            .ToList();
    }

    public List<Rent> GetListByPendingAll()
    {
        return Rents
            .Where(rent => rent.GiveBack == ECondition.REQUESTED)
            .ToList();
    }

    public List<Rent> GetListByAdminDecision()
    {
        return Rents.Where(rent => rent.GiveBackAdmin is not null).ToList();
    }

    public void SendRequest(Rent rent)
    {
        Console.WriteLine("Give back request sended");
    }

    public void ApproveRequest()
    {
        Console.WriteLine("Give back request approved");
    }

    public void RejectRequest()
    {
        Console.WriteLine("Give back request rejected");
    }
}
