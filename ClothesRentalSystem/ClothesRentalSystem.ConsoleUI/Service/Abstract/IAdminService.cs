using ClothesRentalSystem.ConsoleUI.Entity;

namespace ClothesRentalSystem.ConsoleUI.Service.Abstract;

public interface IAdminService
{
    void Save(string username, string email, string password);
    Admin GetById(long id);
    Admin GetByUsername(string username);
    Admin GetByEmail(string email);
}
