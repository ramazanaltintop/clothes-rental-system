using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.ReturnException;

public class RejectedReturnRequestsNotFoundException : ClothesRentalSystemException
{
    public RejectedReturnRequestsNotFoundException()
        : base("Rejected return requests not found.") { }
}
