using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.AuthException;

public class AlreadyAuthenticatedException : ClothesRentalSystemException
{
    public AlreadyAuthenticatedException(string usernameOrEmail)
        : base($"{usernameOrEmail} already logged in.") { }
}
