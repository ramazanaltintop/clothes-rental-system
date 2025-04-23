using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Entity.Enum;
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
        if (_repository.HasUsername(username)
            || _repository.HasEmail(email))
            throw new Exception("This user already exists");

        User user = new User();
        user.Id = GenerateId.GenerateUserId();
        user.Auth.Username = username;
        user.Auth.Email = email;
        user.Auth.Password = password;
        user.Auth.Role = ERole.USER;

        _repository.Save(user);
    }
    
    public List<User> GetList()
    {
        return _repository.GetList();
    }
    
    public User GetById(long id)
    {
        return _repository.GetById(id)
            ?? throw new Exception("User not found");
    }
    
    public User GetByUsername(string username)
    {
        return _repository.GetByUsername(username)
            ?? throw new Exception("Please check your information");
    }

    public User GetByEmail(string email)
    {
        return _repository.GetByEmail(email)
            ?? throw new Exception("Please check your information");
    }
}
