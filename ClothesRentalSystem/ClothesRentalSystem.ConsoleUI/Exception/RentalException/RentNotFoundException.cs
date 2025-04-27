using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.RentalException;

public class RentNotFoundException : ClothesRentalSystemException
{
    public RentNotFoundException()
        : base("Rental request not found.") { }
}
