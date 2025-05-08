using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.ReturnException;

public class ReturnRequestAlreadySentException : ClothesRentalSystemException
{
    public ReturnRequestAlreadySentException()
        : base("Return request has already been sent for this rental.") { }
}
