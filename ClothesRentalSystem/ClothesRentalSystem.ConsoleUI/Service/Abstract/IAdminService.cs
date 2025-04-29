using ClothesRentalSystem.ConsoleUI.Entity;

namespace ClothesRentalSystem.ConsoleUI.Service.Abstract;

public interface IAdminService
{
    void Save(string username, string email, string password);
    List<Admin> GetList();
    Admin GetById(long id);
    Admin GetByUsername(string username);
    Admin GetByEmail(string email);
    void SaveSuperAdmin(string username, string email, string password);
    void PromoteUserToAdmin(string username);
    void DemoteAdminToUser(string username);
}
