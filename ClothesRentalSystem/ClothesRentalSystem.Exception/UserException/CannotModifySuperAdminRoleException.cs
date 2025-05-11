using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.UserException;

public class CannotModifySuperAdminRoleException : ClothesRentalSystemException
{
    public CannotModifySuperAdminRoleException()
        : base("SuperAdmin role cannot be modified.") { }
}
