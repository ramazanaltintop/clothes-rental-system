using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Entity.Enum;
using ClothesRentalSystem.ConsoleUI.Exception.UserException;
using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Util;

namespace ClothesRentalSystem.ConsoleUI.Service.Concrete;

public class UserServiceImpl : IUserService
{
    private readonly UserRepository _repository;

    public UserServiceImpl(UserRepository repository)
    {
        _repository = repository;
    }

    public void Save(string username, string email, string password)
    {
        if (HasUsername(username)
            || _repository.HasEmail(email))
            throw new UserAlreadyExistsException();

        User user = new User();
        user.Id = GenerateId.GenerateUserId();
        user.Auth.Username = username;
        user.Auth.Email = email;
        user.Auth.Password = password;
        user.Auth.Role = ERole.USER;

        _repository.Save(user);
    }
    
    public User GetById(long id)
    {
        return _repository.GetById(id)
            ?? throw new UserNotFoundException($"Id {id}");
    }
    
    public User GetByUsername(string username)
    {
        return _repository.GetByUsername(username)
            ?? throw new UserNotFoundException($"Username {username}");
    }

    public User GetByEmail(string email)
    {
        return _repository.GetByEmail(email)
            ?? throw new UserNotFoundException($"Email {email}");
    }

    public void Remove(long id)
    {
        User user = _repository.GetById(id)
            ?? throw new UserNotFoundException($"Id {id}");

        _repository.Remove(user);
    }

    public bool HasUsername(string username)
    {
        return _repository.HasUsername(username);
    }
}
