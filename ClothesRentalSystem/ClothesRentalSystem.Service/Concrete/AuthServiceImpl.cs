using ClothesRentalSystem.Entity;
using ClothesRentalSystem.Entity.Enum;
using ClothesRentalSystem.Exception.AuthException;
using ClothesRentalSystem.Exception.UserException;
using ClothesRentalSystem.Repository;
using ClothesRentalSystem.Service.Abstract;

namespace ClothesRentalSystem.Service.Concrete;

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
        User? user = _userService.GetByUsername(usernameOrEmail);

        if (user is null)
            user = _userService.GetByEmail(usernameOrEmail);

        if (user is null)
            throw new UserNotFoundException();

        if (!user.Auth.Password.Equals(password))
            throw new InvalidPasswordException();

        return _repository.SignIn(user);
    }

    public bool SignOut()
    {
        User user = _userService.GetById(List.UserId);

        return _repository.SignOut();
    }

    public bool HasSuperAdmin()
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role != ERole.SUPERADMIN)
            throw new SuperAdminAccessOnlyException();

        return true;
    }

    public ERole GetRole(long userId)
    {
        User user = _userService.GetById(userId);

        if (user.Auth is null)
            throw new AuthNotFoundException();

        return user.Auth.Role;
    }
}
