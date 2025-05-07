using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Service.Concrete;

namespace ClothesRentalSystem.ConsoleUI.Presentation;

public class AdminController
{
    private readonly IAdminService _adminService;

    public AdminController()
    {
        _adminService = new AdminServiceImpl(new AdminRepository(),
            new UserServiceImpl(new UserRepository()));
    }

    public List<Admin> GetList()
    {
        return _adminService.GetList();
    }

    public void ChangePasswordWithUsername(string username, string oldPassword, string newPassword)
    {
        _adminService.ChangePasswordWithUsername(username, oldPassword, newPassword);
    }

    public void ChangePasswordWithEmail(string email, string oldPassword, string newPassword)
    {
        _adminService.ChangePasswordWithEmail(email, oldPassword, newPassword);
    }

    public void PromoteUserToAdmin(string username)
    {
        _adminService.PromoteUserToAdmin(username);
    }

    public void DemoteAdminToUser(string username)
    {
        _adminService.DemoteAdminToUser(username);
    }
}
