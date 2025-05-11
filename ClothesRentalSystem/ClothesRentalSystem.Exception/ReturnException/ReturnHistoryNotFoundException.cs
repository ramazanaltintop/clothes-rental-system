using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.ReturnException;

public class ReturnHistoryNotFoundException : ClothesRentalSystemException
{
    public ReturnHistoryNotFoundException()
        : base("Return history not found.") { }
}
