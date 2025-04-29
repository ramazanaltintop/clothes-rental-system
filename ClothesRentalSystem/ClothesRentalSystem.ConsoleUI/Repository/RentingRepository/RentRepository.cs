using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Entity.Enum;

namespace ClothesRentalSystem.ConsoleUI.Repository.RentingRepository;

public class RentRepository : List
{
    public Rent? GetById(long id)
    {
        return Rents.FirstOrDefault(rent => rent.Id == id);
    }

    public void SendRequest(Rent rent)
    {
        Rents.Add(rent);
    }

    public bool ApproveRequest(Rent rent)
    {
        Console.WriteLine($"{rent.Clothes.Name} rental request approved");
        return true;
    }

    public bool RejectRequest(Rent rent)
    {
        Console.WriteLine($"{rent.Clothes.Name} rental request rejected");
        return true;
    }

    public List<Rent> GetListByApproved(long peopleId)
    {
        return Rents
            .Where(rent =>
                rent.User.Id == peopleId &&
                rent.IsApproved == ECondition.APPROVED)
            .ToList();
    }

    public List<Rent> GetListByPending(long peopleId)
    {
        return Rents
            .Where(rent =>
                rent.User.Id == peopleId &&
                rent.IsApproved == ECondition.REQUESTED)
            .ToList();
    }

    public List<Rent> GetListByRejected(long peopleId)
    {
        return Rents
            .Where(rent =>
                rent.User.Id == peopleId &&
                rent.IsApproved == ECondition.REJECTED)
            .ToList();
    }

    public List<Rent> GetListByApprovedOrRejected(long peopleId)
    {
        return Rents.Where(rent =>
            rent.User.Id == peopleId &&
            (rent.IsApproved == ECondition.APPROVED ||
            rent.IsApproved == ECondition.REJECTED))
            .ToList();
    }

    public List<Rent> GetListByUsername(string username)
    {
        return Rents.Where(rent => rent.User.Auth.Username.Equals(username)).ToList();
    }

    public List<Rent> GetListByPendingAll()
    {
        return Rents
            .Where(rent => rent.IsApproved == ECondition.REQUESTED)
            .ToList();
    }
}
