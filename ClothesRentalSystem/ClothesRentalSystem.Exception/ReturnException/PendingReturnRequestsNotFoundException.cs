using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.ReturnException;

public class PendingReturnRequestsNotFoundException : ClothesRentalSystemException
{
    public PendingReturnRequestsNotFoundException()
        : base("Pending return requests not found.") { }
}
