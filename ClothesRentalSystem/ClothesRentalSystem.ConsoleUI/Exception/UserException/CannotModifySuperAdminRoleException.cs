using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.UserException;

public class CannotModifySuperAdminRoleException : ClothesRentalSystemException
{
    public CannotModifySuperAdminRoleException()
        : base("SuperAdmin role cannot be modified.") { }
}
