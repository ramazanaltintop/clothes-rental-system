using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.GiveBackException;

public class PendingGiveBackRequestsNotFoundException : ClothesRentalSystemException
{
    public PendingGiveBackRequestsNotFoundException()
        : base("Pending give back requests not found.") { }
}
