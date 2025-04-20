using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Service.Concrete;

namespace ClothesRentalSystem.ConsoleUI.Presentation;

public class AdminController
{
    private readonly IAdminService _adminService;

    public AdminController()
    {
        _adminService = new AdminServiceImpl(new AdminRepository());
    }

    public void Save(string username, string email, string password)
    {
        _adminService.Save(username, email, password);
    }
}
