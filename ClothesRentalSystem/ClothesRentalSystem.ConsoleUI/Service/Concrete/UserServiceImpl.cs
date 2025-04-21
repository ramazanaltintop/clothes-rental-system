using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Entity.Enums;
using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;

namespace ClothesRentalSystem.ConsoleUI.Service.Concrete;

public class UserServiceImpl : IUserService
{
    private readonly UserRepository _repository;

    public UserServiceImpl(UserRepository repository)
    {
        _repository = repository;
    }

    public User GetByEmail(string email)
    {
        return _repository.GetByEmail(email)
            ?? throw new Exception("Please check your information");
    }

    public User GetByUsername(string username)
    {
        return _repository.GetByUsername(username)
            ?? throw new Exception("Please check your information");
    }

    public void Save(string username, string email, string password)
    {
        if (_repository.HasUsername(username)
            || _repository.HasEmail(email))
            throw new Exception("This user already exists");

        User user = new User();
        user.Username = username;
        user.Email = email;
        user.Password = password;
        user.Role = Role.User;

        _repository.Save(user);
    }
}
