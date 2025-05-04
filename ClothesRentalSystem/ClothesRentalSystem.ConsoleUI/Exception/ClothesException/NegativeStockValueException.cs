using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.ClothesException;

public class NegativeStockValueException : ClothesRentalSystemException
{
    public NegativeStockValueException()
        : base("Stock value cannot be negative.") { }
}
