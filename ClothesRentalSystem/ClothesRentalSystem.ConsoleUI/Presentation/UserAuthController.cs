using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Service.Concrete;

namespace ClothesRentalSystem.ConsoleUI.Presentation;

public class UserAuthController
{
    private readonly IUserAuthService _userAuthService;

    public UserAuthController()
    {
        _userAuthService = new UserAuthServiceImpl(
            new AuthRepository(),
            new UserServiceImpl(new UserRepository()));
    }
    
    public long SignInWithUsername(string username, string password)
    {
        return _userAuthService.SignInWithUsername(username, password);
    }

    public long SignInWithEmail(string email, string password)
    {
        return _userAuthService.SignInWithEmail(email, password);
    }

    public bool SignOut()
    {
        return _userAuthService.SignOut();
    }
}
