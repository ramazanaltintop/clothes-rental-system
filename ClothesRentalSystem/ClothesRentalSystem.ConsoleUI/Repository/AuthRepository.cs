using ClothesRentalSystem.ConsoleUI.Entity;

namespace ClothesRentalSystem.ConsoleUI.Repository;

public class AuthRepository : List
{
    public int SignIn(Auth auth)
    {
        auths.Add(auth);

        string identity = string.IsNullOrEmpty(auth.Username) ? auth.Email : auth.Username;
        Console.WriteLine($"{identity} successfully signed in\n");

        return auth.Id;
    }

    public bool SignOut(Auth auth)
    {
        auths.Remove(auth);

        string identity = string.IsNullOrEmpty(auth.Username) ? auth.Email : auth.Username;
        Console.WriteLine($"{identity} successfully signed out\n");

        return true;
    }

    public Auth? GetById(int id)
    {
        return auths.FirstOrDefault(auth => auth.Id == id);
    }

    public bool HasUsernameSignedInBefore(string username)
    {
        return auths.Any(auth => auth.Username.Equals(username));
    }

    public bool HasEmailSignedInBefore(string email)
    {
        return auths.Any(auth => auth.Email.Equals(email));
    }
}
