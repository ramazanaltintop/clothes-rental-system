using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.UserException;

public class UserNotFoundException : ClothesRentalSystemException
{
    public UserNotFoundException()
        : base($"User not found.") { }
}
