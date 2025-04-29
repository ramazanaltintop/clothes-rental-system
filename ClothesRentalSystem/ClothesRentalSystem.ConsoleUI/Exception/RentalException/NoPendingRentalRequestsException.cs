using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.RentalException;

public class NoPendingRentalRequestsException : ClothesRentalSystemException
{
    public NoPendingRentalRequestsException()
        : base("No pending rental requests found.") { }
}
