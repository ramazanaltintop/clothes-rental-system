using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.ReturnException;

public class ReturnRequestAlreadySentException : ClothesRentalSystemException
{
    public ReturnRequestAlreadySentException()
        : base("Return request has already been sent for this rental.") { }
}
