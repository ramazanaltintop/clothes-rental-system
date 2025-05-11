using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.ClothingItemException;

public class NegativePriceException : ClothesRentalSystemException
{
    public NegativePriceException()
        : base("Price must be greater than zero.") { }
}
