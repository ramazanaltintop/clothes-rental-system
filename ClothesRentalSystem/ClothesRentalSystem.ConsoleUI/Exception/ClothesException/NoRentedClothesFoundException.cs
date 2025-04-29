using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.ClothesException;

public class NoRentedClothesFoundException : ClothesRentalSystemException
{
    public NoRentedClothesFoundException()
        : base("No rented clothes found.") { }
}
