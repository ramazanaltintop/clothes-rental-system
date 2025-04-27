using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.CategoryException;

public class CategoryNotFoundException : ClothesRentalSystemException
{
    public CategoryNotFoundException(string detail)
        : base($"Category not found: {detail}") { }
}
