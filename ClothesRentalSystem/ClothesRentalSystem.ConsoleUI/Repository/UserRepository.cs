using ClothesRentalSystem.ConsoleUI.Entity;

namespace ClothesRentalSystem.ConsoleUI.Repository;

public class UserRepository : List
{
    public void Save(User user)
    {
        users.Add(user);
    }

    public User? GetByUsername(string username)
    {
        return users.FirstOrDefault(user => user.Username.Equals(username));
    }

    public User? GetByEmail(string email)
    {
        return users.FirstOrDefault(user => user.Email.Equals(email));
    }

    public bool HasUsername(string username)
    {
        return users.Any(user => user.Username.Equals(username));
    }

    public bool HasEmail(string email)
    {
        return users.Any(user => user.Email.Equals(email));
    }
}
