using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.ReturnException;

public class ReturnRequestAlreadyApprovedException : ClothesRentalSystemException
{
    public ReturnRequestAlreadyApprovedException()
        : base("Return request has already been approved for this rental.") { }
}
