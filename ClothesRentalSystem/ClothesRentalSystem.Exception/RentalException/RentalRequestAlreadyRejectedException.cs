using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.RentalException;

public class RentalRequestAlreadyRejectedException : ClothesRentalSystemException
{
    public RentalRequestAlreadyRejectedException()
        : base("Rental request has already been rejected for this rental.") { }
}
