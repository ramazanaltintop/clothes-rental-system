using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.ReturnException;

public class ReturnNotFoundException : ClothesRentalSystemException
{
    public ReturnNotFoundException()
        : base("No pending, approved, or rejected return request was found for this user.") { }
}
