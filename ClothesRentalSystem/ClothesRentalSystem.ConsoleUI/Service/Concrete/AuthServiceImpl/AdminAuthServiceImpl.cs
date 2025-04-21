using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Entity.Enums;
using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Util;

namespace ClothesRentalSystem.ConsoleUI.Service.Concrete.AuthServiceImpl;

public class AdminAuthServiceImpl : IAuthService
{
    private readonly AuthRepository _repository;
    private readonly IAdminService _adminService;

    public AdminAuthServiceImpl(AuthRepository repository,
        IAdminService adminService,
        IUserService userService)
    {
        _repository = repository;
        _adminService = adminService;
    }

    public int SignInWithUsername(string username, string password)
    {
        if (_repository.HasUsernameSignedInBefore(username))
            throw new Exception("You have already signed to system");

        Admin admin = _adminService.GetByUsername(username);
        if (!admin.Password.Equals(password))
            throw new Exception("Incorrect password");

        Auth auth = new Auth();
        auth.Id = GenerateId.GenerateAuthId();
        auth.Username = username;
        auth.Role = admin.Role;
        auth.LogInDate = DateTime.UtcNow;

        return _repository.SignIn(auth);
    }

    public int SignInWithEmail(string email, string password)
    {
        if (_repository.HasEmailSignedInBefore(email))
            throw new Exception("You have already signed to system");

        Admin admin = _adminService.GetByEmail(email);

        if (!admin.Password.Equals(password))
            throw new Exception("Incorrect password");

        Auth auth = new Auth();
        auth.Id = GenerateId.GenerateAuthId();
        auth.Email = email;
        auth.Role = admin.Role;
        auth.LogInDate = DateTime.UtcNow;

        return _repository.SignIn(auth);
    }

    public bool SignOut(int id)
    {
        Auth auth = _repository.GetById(id)
            ?? throw new Exception("You have not already signed in the system");

        return _repository.SignOut(auth);
    }
}
