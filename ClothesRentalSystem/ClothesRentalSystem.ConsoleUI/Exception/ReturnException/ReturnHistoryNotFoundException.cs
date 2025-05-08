using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.ReturnException;

public class ReturnHistoryNotFoundException : ClothesRentalSystemException
{
    public ReturnHistoryNotFoundException()
        : base("Return history not found.") { }
}
