using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.AuthException;

public class RoleNotFoundException : ClothesRentalSystemException
{
    public RoleNotFoundException()
        : base("Role not found.") { }
}
