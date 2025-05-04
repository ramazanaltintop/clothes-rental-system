using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Service.Concrete;

namespace ClothesRentalSystem.ConsoleUI.Presentation;

public class AdminAuthController
{
    private readonly IAdminAuthService _adminAuthService;

    public AdminAuthController()
    {
        _adminAuthService = new AdminAuthServiceImpl(
            new AuthRepository(),
            new AdminServiceImpl(new AdminRepository(),
                new UserServiceImpl(new UserRepository())));
    }

    public long SignInWithUsername(string username, string password)
    {
        return _adminAuthService.SignInWithUsername(username, password);
    }

    public long SignInWithEmail(string email, string password)
    {
        return _adminAuthService.SignInWithEmail(email, password);
    }

    public bool SignOut()
    {
        return _adminAuthService.SignOut();
    }

    public bool HasSuperAdmin()
    {
        return _adminAuthService.HasSuperAdmin();
    }
}
