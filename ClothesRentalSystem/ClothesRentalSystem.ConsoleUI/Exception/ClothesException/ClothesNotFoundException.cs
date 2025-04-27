using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.ClothesException;

public class ClothesNotFoundException : ClothesRentalSystemException
{
    public ClothesNotFoundException(string detail)
        : base($"Clothes not found : {detail}") { }
}
