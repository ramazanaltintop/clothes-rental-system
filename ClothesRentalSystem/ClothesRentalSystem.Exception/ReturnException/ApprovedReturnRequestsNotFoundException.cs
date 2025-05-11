using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.ReturnException;

public class ApprovedReturnRequestsNotFoundException : ClothesRentalSystemException
{
    public ApprovedReturnRequestsNotFoundException()
        : base("Approved return requests not found.") { }
}
