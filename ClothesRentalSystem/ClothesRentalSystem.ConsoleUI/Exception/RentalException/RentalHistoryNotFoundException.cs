using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.RentalException;

public class RentalHistoryNotFoundException : ClothesRentalSystemException
{
    public RentalHistoryNotFoundException()
        : base("Rental history not found.") { }
}
