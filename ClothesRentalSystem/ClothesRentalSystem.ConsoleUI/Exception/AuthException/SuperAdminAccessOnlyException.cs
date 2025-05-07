using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.AuthException;

public class SuperAdminAccessOnlyException : ClothesRentalSystemException
{
    public SuperAdminAccessOnlyException()
        : base("Only SuperAdmin can perform this action.") { }
}
