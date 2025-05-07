using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.ClothingItemException;

public class ClothingItemAlreadyExistsException : ClothesRentalSystemException
{
    public ClothingItemAlreadyExistsException(string clothingItemName)
        : base($"Clothing item {clothingItemName} already exists.") { }
}
