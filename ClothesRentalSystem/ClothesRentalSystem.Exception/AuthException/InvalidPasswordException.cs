using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.AuthException;

public class InvalidPasswordException : ClothesRentalSystemException
{
    public InvalidPasswordException()
        : base("Invalid password.") { }
}
