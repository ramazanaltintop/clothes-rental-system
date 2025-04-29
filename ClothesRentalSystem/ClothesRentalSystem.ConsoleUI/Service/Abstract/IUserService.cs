using ClothesRentalSystem.ConsoleUI.Entity;

namespace ClothesRentalSystem.ConsoleUI.Service.Abstract;

public interface IUserService
{
    void Save(string username, string email, string password);
    List<User> GetList();
    User GetById(long id);
    User GetByUsername(string username);
    User GetByEmail(string email);
    void Remove(long id);
}
