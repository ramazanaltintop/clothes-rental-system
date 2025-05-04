using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.GiveBackException;

public class GiveBackRequestNotFoundException : ClothesRentalSystemException
{
    public GiveBackRequestNotFoundException()
        : base("Give Back request not found.") { }
}
