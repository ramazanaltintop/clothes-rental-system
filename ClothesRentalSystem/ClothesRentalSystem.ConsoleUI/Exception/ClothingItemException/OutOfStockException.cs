using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.ClothingItemException;

public class OutOfStockException : ClothesRentalSystemException
{
    public OutOfStockException()
        : base("This clothing item is out of stock and cannot be rented.") { }
}
