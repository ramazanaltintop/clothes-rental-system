using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.GiveBackException;

public class GiveBackRequestNotAllowedException : ClothesRentalSystemException
{
    public GiveBackRequestNotAllowedException()
        : base("Give back request can only be created for accepted rental requests.") { }
}
