using ClothesRentalSystem.Entity;

namespace ClothesRentalSystem.Repository;

public class AuthRepository : List
{
    public long SignIn(User user)
    {
        return user.Id;
    }

    public bool SignOut()
    {
        return true;
    }
}
