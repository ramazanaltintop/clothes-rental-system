using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.GiveBackException;

public class GiveBackRequestAlreadySentException : ClothesRentalSystemException
{
    public GiveBackRequestAlreadySentException()
        : base("Give back request has already been sent for this rental.") { }
}
