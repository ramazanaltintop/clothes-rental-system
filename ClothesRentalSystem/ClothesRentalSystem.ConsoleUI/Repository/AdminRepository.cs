using ClothesRentalSystem.ConsoleUI.Entity;

namespace ClothesRentalSystem.ConsoleUI.Repository;

public class AdminRepository : List
{
    public void Save(Admin admin)
    {
        admins.Add(admin);
    }

    public Admin? GetByUsername(string username)
    {
        return admins.FirstOrDefault(admin => admin.Username.Equals(username));
    }

    public Admin? GetByEmail(string email)
    {
        return admins.FirstOrDefault(admin => admin.Email.Equals(email));
    }

    public bool HasUsername(string username)
    {
        return admins.Any(admin => admin.Username.Equals(username));
    }

    public bool HasEmail(string email)
    {
        return admins.Any(admin => admin.Email.Equals(email));
    }
}
