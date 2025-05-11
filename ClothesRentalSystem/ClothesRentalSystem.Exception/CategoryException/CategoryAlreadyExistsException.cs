using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.CategoryException;

public class CategoryAlreadyExistsException : ClothesRentalSystemException
{
    public CategoryAlreadyExistsException(string categoryName)
        : base($"Category {categoryName} already exists.") { }
}
