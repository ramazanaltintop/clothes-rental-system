using ClothesRentalSystem.ConsoleUI.Entity;

namespace ClothesRentalSystem.ConsoleUI.Service.Abstract;

public interface IUserService
{
    void Save(string username, string email, string password);
    User GetByUsername(string username);
    User GetByEmail(string email);
}
