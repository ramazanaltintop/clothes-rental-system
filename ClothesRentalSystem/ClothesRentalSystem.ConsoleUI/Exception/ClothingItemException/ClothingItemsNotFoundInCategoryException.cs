using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.ClothingItemException;

public class ClothingItemsNotFoundInCategoryException : ClothesRentalSystemException
{
    public ClothingItemsNotFoundInCategoryException(string category)
        : base($"Clothing items not found in the category: {category}.") { }
}
