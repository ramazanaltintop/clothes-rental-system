using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.AuthException;

public class UserAccessOnlyException : ClothesRentalSystemException
{
    public UserAccessOnlyException()
        : base("You are not authorized to perform this action.") { }
}
