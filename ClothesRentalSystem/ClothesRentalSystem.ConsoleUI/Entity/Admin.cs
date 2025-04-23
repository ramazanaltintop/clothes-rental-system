using ClothesRentalSystem.ConsoleUI.Entity.Base;

namespace ClothesRentalSystem.ConsoleUI.Entity;

public class Admin : BaseLongEntity
{
    public Auth Auth { get; set; }
    public DateTime CreatedAt { get; set; }

    public Admin()
    {
        CreatedAt = DateTime.UtcNow;
        Auth = new Auth();
    }

    public override string ToString()
    {
        return base.ToString() +
            $"Username : {Auth.Username}\n" +
            $"Email : {Auth.Email}\n" +
            $"Password : {Auth.Password}\n" +
            $"Role : {Auth.Role.ToString()}\n" +
            $"CreatedAt : {CreatedAt}\n";
    }
}
