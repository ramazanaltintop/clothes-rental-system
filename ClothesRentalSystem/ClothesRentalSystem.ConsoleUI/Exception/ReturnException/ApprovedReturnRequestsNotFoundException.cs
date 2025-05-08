using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.ReturnException;

public class ApprovedReturnRequestsNotFoundException : ClothesRentalSystemException
{
    public ApprovedReturnRequestsNotFoundException()
        : base("Approved return requests not found.") { }
}
