using ClothesRentalSystem.Entity;
using ClothesRentalSystem.Entity.Enum;

namespace ClothesRentalSystem.Repository;

public class UserRepository : List
{
    public void Save(User user)
    {
        Users.Add(user);
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

    public bool Update(User user)
    {
        return true;
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
