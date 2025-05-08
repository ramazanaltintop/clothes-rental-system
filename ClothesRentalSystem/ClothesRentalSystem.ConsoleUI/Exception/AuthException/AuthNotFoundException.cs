using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.AuthException;

public class AuthNotFoundException : ClothesRentalSystemException
{
    public AuthNotFoundException()
        : base("Authentication record not found.") { }
}
