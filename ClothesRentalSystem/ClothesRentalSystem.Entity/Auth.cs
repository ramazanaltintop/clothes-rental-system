using ClothesRentalSystem.Entity.Base;
using ClothesRentalSystem.Entity.Enum;

namespace ClothesRentalSystem.Entity;

public class Auth : BaseEntity<long>
{
    public long UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public ERole Role { get; set; }
}
