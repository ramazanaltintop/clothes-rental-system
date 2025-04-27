using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.AdminException;

public class AdminNotFoundException : ClothesRentalSystemException
{
    public AdminNotFoundException(string detail)
        : base($"Admin not found: {detail}") { }
}
