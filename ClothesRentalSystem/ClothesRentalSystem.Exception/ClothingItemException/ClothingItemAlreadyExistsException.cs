using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.ClothingItemException;

public class ClothingItemAlreadyExistsException : ClothesRentalSystemException
{
    public ClothingItemAlreadyExistsException(string clothingItemName)
        : base($"Clothing item {clothingItemName} already exists.") { }
}
