using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.UserException;

public class UserNotFoundException : ClothesRentalSystemException
{
    public UserNotFoundException()
        : base($"User not found.") { }
}
