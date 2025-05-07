using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.RentalException;

public class PendingRentalRequestsNotFoundException : ClothesRentalSystemException
{
    public PendingRentalRequestsNotFoundException()
        : base("Pending rental requests not found.") { }
}
