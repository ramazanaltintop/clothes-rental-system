using ClothesRentalSystem.ConsoleUI.Entity;

namespace ClothesRentalSystem.ConsoleUI.Repository;

// Database Simulation
public class List
{
    protected static List<Admin> Admins = new List<Admin>();
    protected static List<Auth> Auths = new List<Auth>();
    protected static List<User> Users = new List<User>();
    protected static List<Category> Categories = new List<Category>();
    protected static List<Clothes> Clothes = new List<Clothes>();
    protected static List<Rent> Rents = new List<Rent>();
}
