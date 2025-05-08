using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.ReturnException;

public class ReturnRequestNotFoundException : ClothesRentalSystemException
{
    public ReturnRequestNotFoundException()
        : base("Return request not found.") { }
}
