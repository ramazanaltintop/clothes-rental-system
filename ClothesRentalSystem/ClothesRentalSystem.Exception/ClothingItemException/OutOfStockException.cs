using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.ClothingItemException;

public class OutOfStockException : ClothesRentalSystemException
{
    public OutOfStockException()
        : base("This clothing item is out of stock and cannot be rented.") { }
}
