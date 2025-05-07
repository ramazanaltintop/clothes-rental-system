using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.UserException;

public class UsersNotFoundException : ClothesRentalSystemException
{
    public UsersNotFoundException()
        : base("Users not found in the system.") { }
}
