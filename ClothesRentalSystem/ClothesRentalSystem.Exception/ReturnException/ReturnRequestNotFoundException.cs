using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.ReturnException;

public class ReturnRequestNotFoundException : ClothesRentalSystemException
{
    public ReturnRequestNotFoundException()
        : base("Return request not found.") { }
}
