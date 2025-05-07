using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Entity.Enum;
using ClothesRentalSystem.ConsoleUI.Exception.AuthException;
using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Util;

namespace ClothesRentalSystem.ConsoleUI.Service.Concrete;

public class AdminAuthServiceImpl : IAdminAuthService
{
    private readonly AuthRepository _repository;
    private readonly IAdminService _adminService;

    public AdminAuthServiceImpl(AuthRepository repository,
        IAdminService adminService)
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
        auth.PersonId = admin.Id;
        auth.Username = username;
        auth.Role = admin.Auth.Role;

        return _repository.SignIn(auth);
    }

    public long SignInWithEmail(string email, string password)
    {
        if (_repository.HasEmailSignedInBefore(email))
            throw new AlreadyAuthenticatedException(email);

        Admin admin = _adminService.GetByEmail(email);

        if (!admin.Auth.Password.Equals(password))
            throw new InvalidPasswordException();

        Auth auth = new Auth();
        auth.Id = GenerateId.GenerateAuthId();
        auth.PersonId = admin.Id;
        auth.Email = email;
        auth.Role = admin.Auth.Role;

        return _repository.SignIn(auth);
    }

    public bool SignOut()
    {
        Auth auth = _repository.GetByPersonId(FeAdminSignInMenu.PersonId)
            ?? throw new NotAuthenticatedException();

        return _repository.SignOut(auth);
    }

    public bool HasSuperAdmin()
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.PersonId);

        if (admin.Auth.Role != ERole.SUPERADMIN)
            throw new SuperAdminAccessOnlyException();

        return true;
    }
}
