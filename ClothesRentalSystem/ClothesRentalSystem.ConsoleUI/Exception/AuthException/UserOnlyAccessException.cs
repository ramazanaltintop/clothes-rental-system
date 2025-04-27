using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.AuthException;

public class UserOnlyAccessException : ClothesRentalSystemException
{
    public UserOnlyAccessException()
        : base("You are not authorized to perform this action.") { }
}
