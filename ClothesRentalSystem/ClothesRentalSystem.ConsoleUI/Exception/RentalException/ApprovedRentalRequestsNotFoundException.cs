using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.RentalException;

public class ApprovedRentalRequestsNotFoundException : ClothesRentalSystemException
{
    public ApprovedRentalRequestsNotFoundException()
        : base("Approved rental requests not found.") { }
}
