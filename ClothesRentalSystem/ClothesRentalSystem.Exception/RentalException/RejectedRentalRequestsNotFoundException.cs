using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.RentalException;

public class RejectedRentalRequestsNotFoundException : ClothesRentalSystemException
{
    public RejectedRentalRequestsNotFoundException()
        : base("Rejected rental requests not found.") { }
}
