using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.ReturnException;

public class ReturnNotFoundException : ClothesRentalSystemException
{
    public ReturnNotFoundException()
        : base("No pending, approved, or rejected return request was found for this user.") { }
}
