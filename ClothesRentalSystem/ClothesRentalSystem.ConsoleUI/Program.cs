using ClothesRentalSystem.ConsoleUI.Presentation;

namespace ClothesRentalSystem.ConsoleUI;

public class Program
{
    static void Main(string[] args)
    {
        AdminController adminController = new();
        adminController.Save("admin", "admin@hotmail.com", "Pwd+321");
        adminController.Save("admin2", "admin2@hotmail.com", "Pwd+321");
    }
}
