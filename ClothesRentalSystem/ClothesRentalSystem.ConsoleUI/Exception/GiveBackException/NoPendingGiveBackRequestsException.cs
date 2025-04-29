using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.GiveBackException;

public class NoPendingGiveBackRequestsException : ClothesRentalSystemException
{
    public NoPendingGiveBackRequestsException()
        : base("No pending give back requests found.") { }
}
