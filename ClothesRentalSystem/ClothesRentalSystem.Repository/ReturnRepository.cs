using ClothesRentalSystem.Entity;
using ClothesRentalSystem.Entity.Enum;

namespace ClothesRentalSystem.Repository;

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

    public bool SendRequest(Rent rent)
    {
        return true;
    }

    public bool ApproveRequest()
    {
        return true;
    }

    public bool RejectRequest()
    {
        return true;
    }
}
