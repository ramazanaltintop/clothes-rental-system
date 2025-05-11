using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.UserException;

public class UserAlreadyExistsException : ClothesRentalSystemException
{
    public UserAlreadyExistsException()
        : base($"User with this username or email already exists.") { }
}
