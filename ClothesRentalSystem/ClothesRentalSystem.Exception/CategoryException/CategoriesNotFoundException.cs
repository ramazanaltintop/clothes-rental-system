using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.CategoryException;

public class CategoriesNotFoundException : ClothesRentalSystemException
{
    public CategoriesNotFoundException()
        : base("No categories exist in the system.") { }
}
