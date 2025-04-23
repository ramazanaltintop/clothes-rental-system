namespace ClothesRentalSystem.ConsoleUI.Service.Abstract;

public interface IAuthService
{
    long SignInWithUsername(string username, string password);
    long SignInWithEmail(string email, string password);
    bool SignOut(long peopleId);
}
