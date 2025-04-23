using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Entity.Enum;

namespace ClothesRentalSystem.ConsoleUI.Repository.RentingRepository;

public class GiveBackRepository : List
{
    public bool SendRequest(Rent rent)
    {
        Console.WriteLine($"{rent.Clothes.Name} give back request sended");
        return true;
    }

    public bool ApproveRequest(Rent rent)
    {
        Console.WriteLine($"{rent.Clothes.Name} give back request approved");
        return true;
    }

    public bool RejectRequest(Rent rent)
    {
        Console.WriteLine($"{rent.Clothes.Name} give back request rejected");
        return true;
    }

    public List<Rent> GetListByApproved(long peopleId)
    {
        return Rents
            .Where(rent =>
                rent.User.Id == peopleId &&
                rent.GiveBack == ECondition.APPROVED)
            .ToList();
    }

    public List<Rent> GetListByRequested(long peopleId)
    {
        return Rents
            .Where(rent =>
                rent.User.Id == peopleId &&
                rent.GiveBack == ECondition.REQUESTED)
            .ToList();
    }

    public List<Rent> GetListByRejected(long peopleId)
    {
        return Rents
            .Where(rent =>
                rent.User.Id == peopleId &&
                rent.GiveBack == ECondition.REJECTED)
            .ToList();
    }

    public List<Rent> GetListByApprovedOrRejected(long peopleId)
    {
        return Rents.Where(rent =>
            rent.User.Id == peopleId &&
            (rent.GiveBack == ECondition.APPROVED ||
            rent.GiveBack == ECondition.REJECTED))
            .ToList();
    }
}
