using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Util;

namespace ClothesRentalSystem.ConsoleUI.Service.Concrete.AuthServiceImpl;

public class UserAuthServiceImpl : IAuthService
{
    private readonly AuthRepository _repository;
    private readonly IUserService _userService;

    public UserAuthServiceImpl(AuthRepository repository, IUserService userService)
    {
        _repository = repository;
        _userService = userService;
    }

    public int SignInWithUsername(string username, string password)
    {
        if (_repository.HasUsernameSignedInBefore(username))
            throw new Exception("You have already signed to system");

        User user = _userService.GetByUsername(username);
        if (!user.Password.Equals(password))
            throw new Exception("Incorrect password");

        Auth auth = new Auth();
        auth.Id = GenerateId.GenerateAuthId();
        auth.Username = username;
        auth.Role = user.Role;
        auth.LogInDate = DateTime.UtcNow;

        return _repository.SignIn(auth);
    }

    public int SignInWithEmail(string email, string password)
    {
        if (_repository.HasEmailSignedInBefore(email))
            throw new Exception("You have already signed to system");

        User user = _userService.GetByEmail(email);

        if (!user.Password.Equals(password))
            throw new Exception("Incorrect password");

        Auth auth = new Auth();
        auth.Id = GenerateId.GenerateAuthId();
        auth.Email = email;
        auth.Role = user.Role;
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
