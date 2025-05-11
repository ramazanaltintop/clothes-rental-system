using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.ReturnException;

public class RejectedReturnRequestsNotFoundException : ClothesRentalSystemException
{
    public RejectedReturnRequestsNotFoundException()
        : base("Rejected return requests not found.") { }
}
