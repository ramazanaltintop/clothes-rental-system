using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Service.Concrete;
using ClothesRentalSystem.ConsoleUI.Service.Concrete.AuthServiceImpl;

namespace ClothesRentalSystem.ConsoleUI.Presentation.AuthController;

public class AdminAuthController
{
    private readonly IAuthService _authService;
    private readonly ISuperAdminAuthService _superAdminService;

    public AdminAuthController()
    {
        _authService = new AdminAuthServiceImpl(
            new AuthRepository(),
            new AdminServiceImpl(new AdminRepository(),
                new UserServiceImpl(new UserRepository())),
            new UserServiceImpl(new UserRepository()));
        _superAdminService = new AdminAuthServiceImpl(
            new AuthRepository(),
            new AdminServiceImpl(new AdminRepository(),
                new UserServiceImpl(new UserRepository())),
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

    public bool HasSuperAdmin(long peopleId)
    {
        return _superAdminService.HasSuperAdmin(peopleId);
    }
}
