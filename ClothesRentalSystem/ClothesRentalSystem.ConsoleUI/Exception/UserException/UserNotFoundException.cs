using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.UserException;

public class UserNotFoundException : ClothesRentalSystemException
{
    public UserNotFoundException(string detail)
        : base($"User not found: {detail}") { }
}
