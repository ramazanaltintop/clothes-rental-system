using ClothesRentalSystem.Entity.Base;

namespace ClothesRentalSystem.Entity;

public class User : BaseEntity<long>
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
        return base.ToString() +
            $"Username : {Auth.Username}\n" +
            $"Email : {Auth.Email}\n" +
            $"Password : {Auth.Password}\n" +
            $"Role : {Auth.Role.ToString()}\n" +
            $"CreatedAt : {CreatedAt}\n";
    }
}
