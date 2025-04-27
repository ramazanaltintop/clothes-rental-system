using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Exception.AuthException;
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

    public long SignInWithUsername(string username, string password)
    {
        if (_repository.HasUsernameSignedInBefore(username))
            throw new AlreadyAuthenticatedException(username);

        Admin admin = _adminService.GetByUsername(username);
        if (!admin.Auth.Password.Equals(password))
            throw new InvalidPasswordException();

        Auth auth = new Auth();
        auth.Id = GenerateId.GenerateAuthId();
        auth.PeopleId = admin.Id;
        auth.Username = username;
        auth.Role = admin.Auth.Role;
        auth.SignInDate = DateTime.UtcNow;

        return _repository.SignIn(auth);
    }

    public long SignInWithEmail(string email, string password)
    {
        if (_repository.HasEmailSignedInBefore(email))
            throw new AlreadyAuthenticatedException("You have already signed to system");

        Admin admin = _adminService.GetByEmail(email);

        if (!admin.Auth.Password.Equals(password))
            throw new InvalidPasswordException();

        Auth auth = new Auth();
        auth.Id = GenerateId.GenerateAuthId();
        auth.PeopleId = admin.Id;
        auth.Email = email;
        auth.Role = admin.Auth.Role;
        auth.SignInDate = DateTime.UtcNow;

        return _repository.SignIn(auth);
    }

    public bool SignOut(long peopleId)
    {
        Auth auth = _repository.GetByPeopleId(peopleId)
            ?? throw new NotAuthenticatedException();

        return _repository.SignOut(auth);
    }
}
