using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.ReturnException;

public class ReturnRequestAlreadyRejectedException : ClothesRentalSystemException
{
    public ReturnRequestAlreadyRejectedException()
        : base("Return request has already been rejected for this rental.") { }
}
