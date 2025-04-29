using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.GiveBackException;

public class NoRejectedGiveBackRequestsException : ClothesRentalSystemException
{
    public NoRejectedGiveBackRequestsException()
        : base("No rejected give back requests found.") { }
}
