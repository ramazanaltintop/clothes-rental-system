using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.RentalException;

public class EmptyCartException : ClothesRentalSystemException
{
    public EmptyCartException()
        : base("The rental cart is empty. At least one item is required to proceed.") { }
}
