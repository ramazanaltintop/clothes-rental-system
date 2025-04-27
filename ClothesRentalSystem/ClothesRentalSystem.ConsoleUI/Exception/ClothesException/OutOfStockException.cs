using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.ClothesException;

public class OutOfStockException : ClothesRentalSystemException
{
    public OutOfStockException()
        : base("This clothing item is out of stock and cannot be rented.") { }
}
