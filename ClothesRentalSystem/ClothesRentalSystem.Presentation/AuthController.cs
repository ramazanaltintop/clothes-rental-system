using ClothesRentalSystem.Entity.Enum;
using ClothesRentalSystem.Repository;
using ClothesRentalSystem.Service.Abstract;
using ClothesRentalSystem.Service.Concrete;

namespace ClothesRentalSystem.Presentation;

public class AuthController
{
    private readonly IAuthService _authService;

    public AuthController()
    {
        _authService = new AuthServiceImpl(
            new AuthRepository(),
            new UserServiceImpl(new UserRepository()));
    }
    
    public long SignIn(string usernameOrEmail, string password)
    {
        return _authService.SignIn(usernameOrEmail, password);
    }

    public bool SignOut()
    {
        return _authService.SignOut();
    }

    public bool HasSuperAdmin()
    {
        return _authService.HasSuperAdmin();
    }

    public ERole GetRole(long userId)
    {
        return _authService.GetRole(userId);
    }
}
