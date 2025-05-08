using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Entity.Enum;
using ClothesRentalSystem.ConsoleUI.Exception.AuthException;
using ClothesRentalSystem.ConsoleUI.Exception.UserException;
using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Util;

namespace ClothesRentalSystem.ConsoleUI.Service.Concrete;

public class AuthServiceImpl : IAuthService
{
    private readonly AuthRepository _repository;
    private readonly IUserService _userService;

    public AuthServiceImpl(AuthRepository repository, IUserService userService)
    {
        _repository = repository;
        _userService = userService;
    }

    public long SignIn(string usernameOrEmail, string password)
    {
        if (_repository.HasUsernameSignedInBefore(usernameOrEmail))
            throw new AlreadyAuthenticatedException();

        if (_repository.HasEmailSignedInBefore(usernameOrEmail))
            throw new AlreadyAuthenticatedException();

        User? user = _userService.GetByUsername(usernameOrEmail);

        if (user is null)
            user = _userService.GetByEmail(usernameOrEmail);

        if (user is null)
            throw new UserNotFoundException();

        if (!user.Auth.Password.Equals(password))
            throw new InvalidPasswordException();

        Auth auth = new Auth();
        auth.Id = GenerateId.GenerateAuthId();
        auth.UserId = user.Id;
        auth.Username = usernameOrEmail;
        auth.Role = user.Auth.Role;

        return _repository.SignIn(auth);
    }

    public bool SignOut()
    {
        Auth auth = _repository.GetByUserId(Program.UserId)
            ?? throw new NotAuthenticatedException();

        return _repository.SignOut(auth);
    }

    public bool HasSuperAdmin()
    {
        User user = _userService.GetById(Program.UserId);

        if (user.Auth.Role != ERole.SUPERADMIN)
            throw new SuperAdminAccessOnlyException();

        return true;
    }

    public ERole GetRole(long userId)
    {
        Auth? auth = _repository.GetByUserId(userId);

        if (auth is null)
            throw new AuthNotFoundException();

        return auth.Role;
    }
}
