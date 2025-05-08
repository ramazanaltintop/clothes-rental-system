using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Entity.Enum;

namespace ClothesRentalSystem.ConsoleUI.Repository;

public class ReturnRepository : List
{
    public List<Rent> GetListByUsername(string username)
    {
        return Rents.Where(rent => 
                rent.User.Auth.Username.Equals(username) &&
                rent.ReturnStatus != ECondition.FALSE)
            .ToList();
    }

    public List<Rent> GetListByApproved(long userId)
    {
        return Rents
            .Where(rent =>
                rent.User.Id == userId &&
                rent.ReturnStatus == ECondition.APPROVED)
            .ToList();
    }

    public List<Rent> GetListByPending(long? userId = null)
    {
        var query = Rents.Where(rent =>
            rent.ReturnStatus == ECondition.REQUESTED);

        if (userId.HasValue)
        {
            query = query.Where(rent => rent.User.Id == userId);
        }

        return query.ToList();
    }

    public List<Rent> GetListByRejected(long userId)
    {
        return Rents
            .Where(rent =>
                rent.User.Id == userId &&
                rent.ReturnStatus == ECondition.REJECTED)
            .ToList();
    }

    public List<Rent> GetListByApprovedOrRejected(long userId)
    {
        return Rents.Where(rent =>
            rent.User.Id == userId &&
            (rent.ReturnStatus == ECondition.APPROVED ||
            rent.ReturnStatus == ECondition.REJECTED))
            .ToList();
    }

    public List<Rent> GetListByAdminDecision()
    {
        return Rents.Where(rent => rent.ReturnApprovedBy is not null).ToList();
    }

    public void SendRequest(Rent rent)
    {
        Console.WriteLine("Return request sended");
    }

    public void ApproveRequest()
    {
        Console.WriteLine("Return request approved");
    }

    public void RejectRequest()
    {
        Console.WriteLine("Return request rejected");
    }
}
