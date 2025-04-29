using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.GiveBackException;

public class NoApprovedGiveBackRequestsException : ClothesRentalSystemException
{
    public NoApprovedGiveBackRequestsException()
        : base("No approved give back requests found.") { }
}
