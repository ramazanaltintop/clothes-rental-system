using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Service.Concrete;

namespace ClothesRentalSystem.ConsoleUI.Presentation;

public class UserController
{
    private readonly IUserService _userService;

    public UserController()
    {
        _userService = new UserServiceImpl(new UserRepository());
    }

    public void Save(string username, string email, string password)
    {
        _userService.Save(username, email, password);
    }

    public void ChangePasswordWithUsername(string username, string oldPassword, string newPassword)
    {
        _userService.ChangePasswordWithUsername(username, oldPassword, newPassword);
    }

    public void ChangePasswordWithEmail(string email, string oldPassword, string newPassword)
    {
        _userService.ChangePasswordWithEmail(email, oldPassword, newPassword);
    }
}
