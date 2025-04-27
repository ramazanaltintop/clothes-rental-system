using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.GiveBackException;

public class GiveBackRequestAlreadyApprovedException : ClothesRentalSystemException
{
    public GiveBackRequestAlreadyApprovedException()
        : base("Give back request has already been approved for this rental.") { }
}
