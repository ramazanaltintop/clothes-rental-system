using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.RentalException;

public class RentalRequestAlreadyRejectedException : ClothesRentalSystemException
{
    public RentalRequestAlreadyRejectedException()
        : base("Rental request has already been rejected for this rental.") { }
}
