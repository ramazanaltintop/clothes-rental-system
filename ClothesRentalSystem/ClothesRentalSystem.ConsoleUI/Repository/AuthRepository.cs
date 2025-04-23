using ClothesRentalSystem.ConsoleUI.Entity;

namespace ClothesRentalSystem.ConsoleUI.Repository;

public class AuthRepository : List
{
    public long SignIn(Auth auth)
    {
        Auths.Add(auth);

        string identity = string.IsNullOrEmpty(auth.Username) ? auth.Email : auth.Username;
        Console.WriteLine($"{identity} successfully signed in\n");

        return auth.PeopleId;
    }

    public bool SignOut(Auth auth)
    {
        Auths.Remove(auth);

        string identity = string.IsNullOrEmpty(auth.Username) ? auth.Email : auth.Username;
        Console.WriteLine($"{identity} successfully signed out\n");

        return true;
    }

    public Auth? GetByPeopleId(long peopleId)
    {
        return Auths.FirstOrDefault(auth => auth.PeopleId == peopleId);
    }

    public bool HasUsernameSignedInBefore(string username)
    {
        return Auths.Any(auth => auth.Username.Equals(username));
    }

    public bool HasEmailSignedInBefore(string email)
    {
        return Auths.Any(auth => auth.Email.Equals(email));
    }
}
