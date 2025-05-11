using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.RentalException;

public class PendingRentalRequestsNotFoundException : ClothesRentalSystemException
{
    public PendingRentalRequestsNotFoundException()
        : base("Pending rental requests not found.") { }
}
