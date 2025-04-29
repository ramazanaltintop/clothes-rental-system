using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.RentalException;

public class NoRentalHistoryFoundException : ClothesRentalSystemException
{
    public NoRentalHistoryFoundException()
        : base("No rented clothing items history found.") { }
}
