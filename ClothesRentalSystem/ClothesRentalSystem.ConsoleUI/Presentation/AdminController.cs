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

    public void Save(string username, string email, string password)
    {
        _adminService.Save(username, email, password);
    }

    public List<Admin> GetList()
    {
        return _adminService.GetList();
    }

    public void SaveSuperAdmin(string username, string email, string password)
    {
        _adminService.SaveSuperAdmin(username, email, password);
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
