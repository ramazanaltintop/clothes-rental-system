using ClothesRentalSystem.ConsoleUI.Presentation;

namespace ClothesRentalSystem.ConsoleUI;

public static class SeedData
{
    public static void Start()
    {
        CreateUsers();
        CreateAdmins();
        CreateCategories();
        CreateClothes();
    }

    private static void CreateCategories()
    {
        CategoryController categoryController = new CategoryController();
        categoryController.Save("Takim Elbise");
        categoryController.Save("Gomlek");
        categoryController.Save("Pantolon");
    }

    private static void CreateAdmins()
    {
        AdminController adminController = new AdminController();
        adminController.Save("admin1", "admin1@hotmail.com", "1");
        adminController.Save("admin2", "admin2@hotmail.com", "2");
    }

    private static void CreateUsers()
    {
        UserController userController = new UserController();
        userController.Save("user1", "user1@hotmail.com", "1");
        userController.Save("user2", "user2@hotmail.com", "2");
        userController.Save("user3", "user3@hotmail.com", "3");
    }

    private static void CreateClothes()
    {
        ClothesController clothesController = new ClothesController();
        clothesController.Save("Beyaz Takim Elbise", 500, 13, 1, 1);
        clothesController.Save("Siyah Takim Elbise", 400, 25, 1, 1);
        clothesController.Save("Mavi Takim Elbise", 300, 36, 1, 1);
        clothesController.Save("Beyaz Gomlek", 100, 45, 2, 2);
        clothesController.Save("Siyah Gomlek", 100, 45, 2, 2);
        clothesController.Save("Beyaz Pantolon", 200, 0, 3, 2);
        clothesController.Save("Siyah Pantolon", 200, 0, 3, 2);
    }
}
