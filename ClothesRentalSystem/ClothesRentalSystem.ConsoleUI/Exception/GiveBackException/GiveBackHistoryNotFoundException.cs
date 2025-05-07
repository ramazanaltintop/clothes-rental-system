using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.GiveBackException;

public class GiveBackHistoryNotFoundException : ClothesRentalSystemException
{
    public GiveBackHistoryNotFoundException()
        : base("Give back history not found.") { }
}
