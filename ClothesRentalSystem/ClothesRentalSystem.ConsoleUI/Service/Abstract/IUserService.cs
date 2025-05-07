using ClothesRentalSystem.ConsoleUI.Entity;

namespace ClothesRentalSystem.ConsoleUI.Service.Abstract;

public interface IUserService
{
    void Save(string username, string email, string password);

    User GetById(long id);
    User GetByUsername(string username);
    User GetByEmail(string email);

    void ChangePasswordWithUsername(string username, string oldPassword, string newPassword);
    void ChangePasswordWithEmail(string email, string oldPassword, string newPassword);

    void Remove(long id);

    bool HasUsername(string username);
}
