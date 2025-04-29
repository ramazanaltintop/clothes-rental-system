using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.AuthException;

public class RequireSuperAdminRoleException : ClothesRentalSystemException
{
    public RequireSuperAdminRoleException()
        : base("Only SuperAdmin can perform this action.") { }
}
