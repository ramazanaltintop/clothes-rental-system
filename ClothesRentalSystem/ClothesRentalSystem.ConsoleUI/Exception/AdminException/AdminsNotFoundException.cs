using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.AdminException;

public class AdminsNotFoundException : ClothesRentalSystemException
{
    public AdminsNotFoundException()
        : base("Admins not found in the system.") { }
}
