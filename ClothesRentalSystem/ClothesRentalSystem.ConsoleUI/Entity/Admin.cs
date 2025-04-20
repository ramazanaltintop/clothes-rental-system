using ClothesRentalSystem.ConsoleUI.Entity.Bases;

namespace ClothesRentalSystem.ConsoleUI.Entity;

public class Admin : BaseByteEntity
{
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}
