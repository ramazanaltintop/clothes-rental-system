using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.ReturnException;

public class ReturnRequestAlreadyRejectedException : ClothesRentalSystemException
{
    public ReturnRequestAlreadyRejectedException()
        : base("Return request has already been rejected for this rental.") { }
}
