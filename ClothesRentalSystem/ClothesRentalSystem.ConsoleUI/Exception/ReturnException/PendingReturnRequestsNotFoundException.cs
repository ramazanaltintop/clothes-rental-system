using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.ReturnException;

public class PendingReturnRequestsNotFoundException : ClothesRentalSystemException
{
    public PendingReturnRequestsNotFoundException()
        : base("Pending return requests not found.") { }
}
