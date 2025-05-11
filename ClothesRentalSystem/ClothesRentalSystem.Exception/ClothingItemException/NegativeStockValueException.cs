using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.ClothingItemException;

public class NegativeStockValueException : ClothesRentalSystemException
{
    public NegativeStockValueException()
        : base("Stock value cannot be negative.") { }
}
