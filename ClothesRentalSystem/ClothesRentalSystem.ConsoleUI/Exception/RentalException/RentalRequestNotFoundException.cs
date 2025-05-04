using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.RentalException;

public class RentalRequestNotFoundException : ClothesRentalSystemException
{
    public RentalRequestNotFoundException()
        : base("Rental request not found.") { }
}
