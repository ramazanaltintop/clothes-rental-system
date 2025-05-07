using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.CategoryException;

public class CategoriesNotFoundException : ClothesRentalSystemException
{
    public CategoriesNotFoundException()
        : base("No categories exist in the system.") { }
}
