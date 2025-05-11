using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.AuthException;

public class NotAuthenticatedException : ClothesRentalSystemException
{
    public NotAuthenticatedException()
        : base("You have not already signed in the system.") { }
}
