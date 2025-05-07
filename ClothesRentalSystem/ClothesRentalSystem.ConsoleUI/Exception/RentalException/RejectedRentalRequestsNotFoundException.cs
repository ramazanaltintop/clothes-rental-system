using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.RentalException;

public class RejectedRentalRequestsNotFoundException : ClothesRentalSystemException
{
    public RejectedRentalRequestsNotFoundException()
        : base("Rejected rental requests not found.") { }
}
