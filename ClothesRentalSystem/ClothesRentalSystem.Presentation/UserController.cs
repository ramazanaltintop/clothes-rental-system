using ClothesRentalSystem.Entity;
using ClothesRentalSystem.Repository;
using ClothesRentalSystem.Service.Abstract;
using ClothesRentalSystem.Service.Concrete;

namespace ClothesRentalSystem.Presentation;

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

    public List<User> GetListByRole(string role)
    {
        return _userService.GetListByRole(role);
    }

    public void ChangePassword(string username, string oldPassword, string newPassword)
    {
        _userService.ChangePassword(username, oldPassword, newPassword);
    }

    public void PromoteUserToAdmin(string username)
    {
        _userService.PromoteUserToAdmin(username);
    }

    public void DemoteAdminToUser(string username)
    {
        _userService.DemoteAdminToUser(username);
    }
}
