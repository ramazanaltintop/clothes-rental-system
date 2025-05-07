using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.AuthException;

public class AdminAccessOnlyException : ClothesRentalSystemException
{
    public AdminAccessOnlyException()
        : base("Only Admin or SuperAdmin can perform this action.") { }
}
