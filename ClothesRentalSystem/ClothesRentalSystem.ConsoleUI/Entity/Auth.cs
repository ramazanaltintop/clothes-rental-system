using ClothesRentalSystem.ConsoleUI.Entity.Base;
using ClothesRentalSystem.ConsoleUI.Entity.Enum;

namespace ClothesRentalSystem.ConsoleUI.Entity;

public class Auth : BaseLongEntity
{
    public long PeopleId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; }
    public ERole Role { get; set; }
    public DateTime SignInDate { get; set; }

    public Auth()
    {
        SignInDate = DateTime.UtcNow;
    }

    public override string ToString()
    {
        return base.ToString() +
            $"Username : {Username}\n" +
            $"Email : {Email}\n" +
            $"Password : {Password}\n" +
            $"Role : {Role.ToString()}\n" +
            $"SignInDate : {SignInDate}\n";
    }
}
