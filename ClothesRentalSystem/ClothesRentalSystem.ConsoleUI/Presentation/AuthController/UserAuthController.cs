using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Service.Concrete;
using ClothesRentalSystem.ConsoleUI.Service.Concrete.AuthServiceImpl;

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
    
    public long SignInWithUsername(string username, string password)
    {
        return _authService.SignInWithUsername(username, password);
    }

    public long SignInWithEmail(string email, string password)
    {
        return _authService.SignInWithEmail(email, password);
    }

    public bool SignOut(long peopleId)
    {
        return _authService.SignOut(peopleId);
    }
}
