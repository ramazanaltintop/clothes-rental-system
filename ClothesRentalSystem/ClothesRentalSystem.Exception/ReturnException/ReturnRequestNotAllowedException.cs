using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.ReturnException;

public class ReturnRequestNotAllowedException : ClothesRentalSystemException
{
    public ReturnRequestNotAllowedException()
        : base("Return request can only be created for accepted rental requests.") { }
}
