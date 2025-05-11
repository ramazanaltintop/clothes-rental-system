using ClothesRentalSystem.Entity;

namespace ClothesRentalSystem.Repository;

public class AuthRepository : List
{
    public long SignIn(Auth auth)
    {
        Auths.Add(auth);

        return auth.UserId;
    }

    public bool SignOut(Auth auth)
    {
        Auths.Remove(auth);

        return true;
    }

    public Auth? GetByUserId(long userId)
    {
        return Auths.FirstOrDefault(auth => auth.UserId == userId);
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
