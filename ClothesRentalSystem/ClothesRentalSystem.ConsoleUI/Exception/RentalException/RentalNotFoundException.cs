using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.RentalException;

public class RentalNotFoundException : ClothesRentalSystemException
{
    public RentalNotFoundException()
        : base("No pending, approved, or rejected rental request was found for this user.") { }
}
