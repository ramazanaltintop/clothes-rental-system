using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.ClothingItemException;

public class ClothingItemsNotFoundInCategoryException : ClothesRentalSystemException
{
    public ClothingItemsNotFoundInCategoryException(string category)
        : base($"Clothing items not found in the category: {category}.") { }
}
