using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.ClothingItemException;

public class ClothingItemNotFoundException : ClothesRentalSystemException
{
    public ClothingItemNotFoundException(string detail)
        : base($"Clothing item not found : {detail}") { }
}
