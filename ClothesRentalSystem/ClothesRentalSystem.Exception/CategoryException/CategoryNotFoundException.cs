using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.CategoryException;

public class CategoryNotFoundException : ClothesRentalSystemException
{
    public CategoryNotFoundException(string detail)
        : base($"Category not found: {detail}") { }
}
