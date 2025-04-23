using ClothesRentalSystem.ConsoleUI.Entity;

namespace ClothesRentalSystem.ConsoleUI.Repository;

public class AdminRepository : List
{
    public void Save(Admin admin)
    {
        Admins.Add(admin);
    }

    public Admin? GetById(long id)
    {
        return Admins.FirstOrDefault(admin => admin.Id == id);
    }

    public Admin? GetByUsername(string username)
    {
        return Admins.FirstOrDefault(admin => admin.Auth.Username.Equals(username));
    }

    public Admin? GetByEmail(string email)
    {
        return Admins.FirstOrDefault(admin => admin.Auth.Email.Equals(email));
    }

    public bool HasUsername(string username)
    {
        return Admins.Any(admin => admin.Auth.Username.Equals(username));
    }

    public bool HasEmail(string email)
    {
        return Admins.Any(admin => admin.Auth.Email.Equals(email));
    }
}
