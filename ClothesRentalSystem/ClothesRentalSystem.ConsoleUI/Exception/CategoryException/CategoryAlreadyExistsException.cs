using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.CategoryException;

public class CategoryAlreadyExistsException : ClothesRentalSystemException
{
    public CategoryAlreadyExistsException(string categoryName)
        : base($"Category {categoryName} already exists.") { }
}
