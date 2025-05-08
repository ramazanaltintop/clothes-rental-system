using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.AuthException;

public class RoleNotFoundException : ClothesRentalSystemException
{
    public RoleNotFoundException()
        : base("Role not found.") { }
}
