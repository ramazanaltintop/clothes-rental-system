using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.AuthException;

public class UserAccessOnlyException : ClothesRentalSystemException
{
    public UserAccessOnlyException()
        : base("You are not authorized to perform this action.") { }
}
