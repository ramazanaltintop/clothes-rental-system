using ClothesRentalSystem.ConsoleUI.Entity;

namespace ClothesRentalSystem.ConsoleUI.Repository;

public class UserRepository : List
{
    public void Save(User user)
    {
        Users.Add(user);
    }

    public List<User> GetList()
    {
        return Users;
    }

    public User? GetById(long id)
    {
        return Users.FirstOrDefault(user => user.Id == id);
    }

    public User? GetByUsername(string username)
    {
        return Users.FirstOrDefault(user => user.Auth.Username.Equals(username));
    }

    public User? GetByEmail(string email)
    {
        return Users.FirstOrDefault(user => user.Auth.Email.Equals(email));
    }

    public bool HasUsername(string username)
    {
        return Users.Any(user => user.Auth.Username.Equals(username));
    }

    public bool HasEmail(string email)
    {
        return Users.Any(user => user.Auth.Email.Equals(email));
    }

    public void Remove(User user)
    {
        Users.Remove(user);
    }
}
