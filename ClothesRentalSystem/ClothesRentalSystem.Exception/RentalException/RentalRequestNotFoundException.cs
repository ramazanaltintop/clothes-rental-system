using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.RentalException;

public class RentalRequestNotFoundException : ClothesRentalSystemException
{
    public RentalRequestNotFoundException()
        : base("Rental request not found.") { }
}
