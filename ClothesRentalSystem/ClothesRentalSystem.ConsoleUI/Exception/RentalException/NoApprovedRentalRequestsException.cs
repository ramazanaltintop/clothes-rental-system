using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.RentalException;

public class NoApprovedRentalRequestsException : ClothesRentalSystemException
{
    public NoApprovedRentalRequestsException()
        : base("No approved rental requests found.") { }
}
