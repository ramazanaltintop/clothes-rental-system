using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.RentalException;

public class ApprovedRentalRequestsNotFoundException : ClothesRentalSystemException
{
    public ApprovedRentalRequestsNotFoundException()
        : base("Approved rental requests not found.") { }
}
