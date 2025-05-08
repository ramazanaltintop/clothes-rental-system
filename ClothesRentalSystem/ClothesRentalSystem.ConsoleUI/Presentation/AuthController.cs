using ClothesRentalSystem.ConsoleUI.Entity.Enum;
using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Service.Concrete;

namespace ClothesRentalSystem.ConsoleUI.Presentation;

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
