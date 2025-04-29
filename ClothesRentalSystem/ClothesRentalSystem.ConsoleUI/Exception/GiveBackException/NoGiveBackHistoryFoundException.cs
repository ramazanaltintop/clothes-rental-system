using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.GiveBackException;

public class NoGiveBackHistoryFoundException : ClothesRentalSystemException
{
    public NoGiveBackHistoryFoundException()
        : base("No give back history found.") { }
}
