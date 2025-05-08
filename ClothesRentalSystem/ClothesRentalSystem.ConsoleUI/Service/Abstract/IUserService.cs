using ClothesRentalSystem.ConsoleUI.Entity;

namespace ClothesRentalSystem.ConsoleUI.Service.Abstract;

public interface IUserService
{
    void Save(string username, string email, string password);

    List<User> GetListByRole(string role);
    User GetById(long id);
    User? GetByUsername(string username);
    User? GetByEmail(string email);

    void ChangePassword(string username, string oldPassword, string newPassword);

    bool HasUsername(string username);

    void PromoteUserToAdmin(string username);
    void DemoteAdminToUser(string username);
}
