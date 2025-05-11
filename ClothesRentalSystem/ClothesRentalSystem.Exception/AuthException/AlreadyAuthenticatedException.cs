using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.AuthException;

public class AlreadyAuthenticatedException : ClothesRentalSystemException
{
    public AlreadyAuthenticatedException()
        : base($"You are already logged in.") { }
}
