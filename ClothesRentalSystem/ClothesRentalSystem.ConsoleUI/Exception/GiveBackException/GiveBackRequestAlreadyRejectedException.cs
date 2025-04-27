using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.GiveBackException;

public class GiveBackRequestAlreadyRejectedException : ClothesRentalSystemException
{
    public GiveBackRequestAlreadyRejectedException()
        : base("Give back request has already been rejected for this rental.") { }
}
