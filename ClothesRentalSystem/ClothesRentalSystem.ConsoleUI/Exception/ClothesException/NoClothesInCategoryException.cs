using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.ClothesException;

public class NoClothesInCategoryException : ClothesRentalSystemException
{
    public NoClothesInCategoryException(string category)
        : base($"No clothes found in the category: {category}.") { }
}
