using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Exception.AuthException;
using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Util;

namespace ClothesRentalSystem.ConsoleUI.Service.Concrete;

public class UserAuthServiceImpl : IUserAuthService
{
    private readonly AuthRepository _repository;
    private readonly IUserService _userService;

    public UserAuthServiceImpl(AuthRepository repository, IUserService userService)
    {
        _repository = repository;
        _userService = userService;
    }

    public long SignInWithUsername(string username, string password)
    {
        if (_repository.HasUsernameSignedInBefore(username))
            throw new AlreadyAuthenticatedException(username);

        User user = _userService.GetByUsername(username);

        if (!user.Auth.Password.Equals(password))
            throw new InvalidPasswordException();

        Auth auth = new Auth();
        auth.Id = GenerateId.GenerateAuthId();
        auth.PersonId = user.Id;
        auth.Username = username;
        auth.Role = user.Auth.Role;

        return _repository.SignIn(auth);
    }

    public long SignInWithEmail(string email, string password)
    {
        if (_repository.HasEmailSignedInBefore(email))
            throw new AlreadyAuthenticatedException(email);

        User user = _userService.GetByEmail(email);

        if (!user.Auth.Password.Equals(password))
            throw new InvalidPasswordException();

        Auth auth = new Auth();
        auth.Id = GenerateId.GenerateAuthId();
        auth.PersonId = user.Id;
        auth.Email = email;
        auth.Role = user.Auth.Role;

        return _repository.SignIn(auth);
    }

    public bool SignOut()
    {
        Auth auth = _repository.GetByPersonId(FeUserSignInMenu.personId)
            ?? throw new NotAuthenticatedException();

        return _repository.SignOut(auth);
    }
}
