using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.AdminException;

public class AdminAlreadyExistsException : ClothesRentalSystemException
{
    public AdminAlreadyExistsException()
        : base($"Admin with this username or email already exists.") { }
}
