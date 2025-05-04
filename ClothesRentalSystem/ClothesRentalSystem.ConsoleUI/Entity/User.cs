using ClothesRentalSystem.ConsoleUI.Entity.Base;

namespace ClothesRentalSystem.ConsoleUI.Entity;

public class User : BasePersonEntity
{
    public Auth Auth { get; set; }
    public DateTime CreatedAt { get; set; }

    public User()
    {
        CreatedAt = DateTime.UtcNow;
        Auth = new Auth();
    }

    public override string ToString()
    {
        string message = base.ToString() +
            $"Username : {Auth.Username}\n" +
            $"Email : {Auth.Email}\n" +
            $"Password : {Auth.Password}\n" +
            $"Role : {Auth.Role.ToString()}\n" +
            $"CreatedAt : {CreatedAt}\n";

        return message;
    }
}
