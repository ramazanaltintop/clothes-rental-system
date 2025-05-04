using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.GiveBackException;

public class GiveBackNotFoundException : ClothesRentalSystemException
{
    public GiveBackNotFoundException()
        : base("No pending, approved, or rejected give-back request was found for this user.") { }
}
