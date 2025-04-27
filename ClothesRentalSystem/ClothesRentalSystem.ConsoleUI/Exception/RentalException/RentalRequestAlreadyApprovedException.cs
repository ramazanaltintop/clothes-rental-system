using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.RentalException;

public class RentalRequestAlreadyApprovedException : ClothesRentalSystemException
{
    public RentalRequestAlreadyApprovedException()
        : base("Rental request has already been approved for this rental.") { }
}
