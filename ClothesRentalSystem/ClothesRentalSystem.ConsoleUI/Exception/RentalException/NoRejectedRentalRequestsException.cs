using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.RentalException;

public class NoRejectedRentalRequestsException : ClothesRentalSystemException
{
    public NoRejectedRentalRequestsException()
        : base("No rejected rental requests found.") { }
}
