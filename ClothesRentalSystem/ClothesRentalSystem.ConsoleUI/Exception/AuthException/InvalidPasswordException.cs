using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.AuthException;

public class InvalidPasswordException : ClothesRentalSystemException
{
    public InvalidPasswordException()
        : base("Invalid password.") { }
}
