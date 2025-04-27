using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.ClothesException;

public class ClothesAlreadyExistsException : ClothesRentalSystemException
{
    public ClothesAlreadyExistsException(string clothesName)
        : base($"Clothing item {clothesName} already exists.") { }
}
