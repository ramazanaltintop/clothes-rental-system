using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Service.Concrete;

namespace ClothesRentalSystem.ConsoleUI.Presentation.AuthController;

public class UserAuthController
{
    private readonly IAuthService _authService;

    public UserAuthController()
    {
        _authService = new UserAuthServiceImpl(
            new AuthRepository(),
            new UserServiceImpl(new UserRepository()));
    }

    public int SignInWithUsername(string username, string password)
    {
        return _authService.SignInWithUsername(username, password);
    }

    public int SignInWithEmail(string email, string password)
    {
        return _authService.SignInWithEmail(email, password);
    }

    public bool SignOut(int id)
    {
        return _authService.SignOut(id);
    }
}
