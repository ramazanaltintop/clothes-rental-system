namespace ClothesRentalSystem.ConsoleUI.Service.Abstract;

public interface IAuthService
{
    int SignInWithUsername(string username, string password);
    int SignInWithEmail(string email, string password);
    bool SignOut(int id);
}
