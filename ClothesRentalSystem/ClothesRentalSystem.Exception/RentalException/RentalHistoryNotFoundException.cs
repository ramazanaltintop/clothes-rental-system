using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.RentalException;

public class RentalHistoryNotFoundException : ClothesRentalSystemException
{
    public RentalHistoryNotFoundException()
        : base("Rental history not found.") { }
}
