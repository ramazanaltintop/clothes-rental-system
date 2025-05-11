using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.AuthException;

public class SuperAdminAccessOnlyException : ClothesRentalSystemException
{
    public SuperAdminAccessOnlyException()
        : base("Only SuperAdmin can perform this action.") { }
}
