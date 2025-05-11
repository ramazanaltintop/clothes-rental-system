using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.RentalException;

public class EmptyCartException : ClothesRentalSystemException
{
    public EmptyCartException()
        : base("The rental cart is empty. At least one item is required to proceed.") { }
}
