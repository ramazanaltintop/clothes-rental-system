using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.GiveBackException;

public class ApprovedGiveBackRequestsNotFoundException : ClothesRentalSystemException
{
    public ApprovedGiveBackRequestsNotFoundException()
        : base("Approved give back requests not found.") { }
}
