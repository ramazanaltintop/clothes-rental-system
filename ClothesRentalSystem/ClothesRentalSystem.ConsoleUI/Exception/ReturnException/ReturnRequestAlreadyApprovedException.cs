using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.ReturnException;

public class ReturnRequestAlreadyApprovedException : ClothesRentalSystemException
{
    public ReturnRequestAlreadyApprovedException()
        : base("Return request has already been approved for this rental.") { }
}
