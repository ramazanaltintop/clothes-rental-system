using ClothesRentalSystem.Entity.Enum;

namespace ClothesRentalSystem.Service.Abstract;

public interface IAuthService
{
    long SignIn(string usernameOrEmail, string password);
    bool SignOut();
    bool HasSuperAdmin();
    ERole GetRole(long userId);
}
