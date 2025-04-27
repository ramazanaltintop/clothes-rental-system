using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.AuthException;

public class AdminOnlyAccessException : ClothesRentalSystemException
{
    public AdminOnlyAccessException()
        : base("You are not authorized to perform this action.") { }
}
