using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.AuthException;

public class AuthNotFoundException : ClothesRentalSystemException
{
    public AuthNotFoundException()
        : base("Authentication record not found.") { }
}
