using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.AuthException;

public class AdminAccessOnlyException : ClothesRentalSystemException
{
    public AdminAccessOnlyException()
        : base("Only Admin or SuperAdmin can perform this action.") { }
}
