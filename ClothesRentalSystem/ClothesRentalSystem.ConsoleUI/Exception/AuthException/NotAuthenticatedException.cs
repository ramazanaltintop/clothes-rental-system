using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.AuthException;

public class NotAuthenticatedException : ClothesRentalSystemException
{
    public NotAuthenticatedException()
        : base("You have not already signed in the system.") { }
}
