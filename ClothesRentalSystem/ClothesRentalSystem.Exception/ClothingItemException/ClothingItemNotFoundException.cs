using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.ClothingItemException;

public class ClothingItemNotFoundException : ClothesRentalSystemException
{
    public ClothingItemNotFoundException(string detail)
        : base($"Clothing item not found : {detail}") { }
}
