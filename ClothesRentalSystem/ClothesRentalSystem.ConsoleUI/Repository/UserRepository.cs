using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Entity.Enum;

namespace ClothesRentalSystem.ConsoleUI.Repository;

public class UserRepository : List
{
    public void Save(User user)
    {
        Users.Add(user);
        Console.WriteLine($"{user.Auth.Username} has been registered.");
    }

    public List<User> GetListByRole(ERole result)
    {
        return Users.Where(user => user.Auth.Role == result).ToList();
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

    public void Update(User user)
    {
        Console.WriteLine($"{user.Auth.Username} has been updated.");
    }

    public bool HasUsername(string username)
    {
        return Users.Any(user => user.Auth.Username.Equals(username));
    }

    public bool HasEmail(string email)
    {
        return Users.Any(user => user.Auth.Email.Equals(email));
    }
}
