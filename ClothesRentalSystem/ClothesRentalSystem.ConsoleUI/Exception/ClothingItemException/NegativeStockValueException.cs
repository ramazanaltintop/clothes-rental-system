using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.ClothingItemException;

public class NegativeStockValueException : ClothesRentalSystemException
{
    public NegativeStockValueException()
        : base("Stock value cannot be negative.") { }
}
