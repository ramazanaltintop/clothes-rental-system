using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.AuthException;

public class AlreadyAuthenticatedException : ClothesRentalSystemException
{
    public AlreadyAuthenticatedException()
        : base($"You are already logged in.") { }
}
