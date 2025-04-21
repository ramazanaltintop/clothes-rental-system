using ClothesRentalSystem.ConsoleUI.Entity.Bases;
using ClothesRentalSystem.ConsoleUI.Entity.Enums;

namespace ClothesRentalSystem.ConsoleUI.Entity;

public class User : BasePeopleEntity
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
}
