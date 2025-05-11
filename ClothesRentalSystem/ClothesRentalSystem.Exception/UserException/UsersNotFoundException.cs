using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.UserException;

public class UsersNotFoundException : ClothesRentalSystemException
{
    public UsersNotFoundException()
        : base("Users not found in the system.") { }
}
