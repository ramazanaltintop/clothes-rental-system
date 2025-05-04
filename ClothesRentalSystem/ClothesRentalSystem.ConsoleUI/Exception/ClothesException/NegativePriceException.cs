using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.ClothesException;

public class NegativePriceException : ClothesRentalSystemException
{
    public NegativePriceException()
        : base("Price must be greater than zero.") { }
}
