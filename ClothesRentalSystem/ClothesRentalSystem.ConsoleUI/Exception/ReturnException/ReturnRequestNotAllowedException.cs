using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.ReturnException;

public class ReturnRequestNotAllowedException : ClothesRentalSystemException
{
    public ReturnRequestNotAllowedException()
        : base("Return request can only be created for accepted rental requests.") { }
}
