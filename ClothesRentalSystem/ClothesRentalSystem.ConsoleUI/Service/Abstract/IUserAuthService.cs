namespace ClothesRentalSystem.ConsoleUI.Service.Abstract;

public interface IUserAuthService
{
    long SignInWithUsername(string username, string password);
    long SignInWithEmail(string email, string password);
    bool SignOut();
}
