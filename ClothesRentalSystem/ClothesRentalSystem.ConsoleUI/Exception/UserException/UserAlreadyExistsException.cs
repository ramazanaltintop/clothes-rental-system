using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.UserException;

public class UserAlreadyExistsException : ClothesRentalSystemException
{
    public UserAlreadyExistsException()
        : base($"User with this username or email already exists.") { }
}
