using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.RentalException;

public class RentalRequestAlreadyApprovedException : ClothesRentalSystemException
{
    public RentalRequestAlreadyApprovedException()
        : base("Rental request has already been approved for this rental.") { }
}
