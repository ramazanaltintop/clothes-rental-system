using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.GiveBackException;

public class RejectedGiveBackRequestsNotFoundException : ClothesRentalSystemException
{
    public RejectedGiveBackRequestsNotFoundException()
        : base("Rejected give back requests not found.") { }
}
