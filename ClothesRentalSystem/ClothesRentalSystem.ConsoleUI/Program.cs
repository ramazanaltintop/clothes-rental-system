using ClothesRentalSystem.ConsoleUI.Presentation;
using ClothesRentalSystem.ConsoleUI.Presentation.AuthController;

namespace ClothesRentalSystem.ConsoleUI;

public class Program
{
    static void Main(string[] args)
    {
        // ADMIN

        AdminController adminController = new AdminController();
        adminController.Save("admin", "admin@hotmail.com", "Pwd+321");
        adminController.Save("admin2", "admin2@hotmail.com", "Pwd+412");

        AdminAuthController adminAuthController = new AdminAuthController();
        int adminAuth1Id = adminAuthController.SignInWithUsername("admin", "Pwd+321");
        int adminAuth2Id = adminAuthController.SignInWithEmail("admin2@hotmail.com", "Pwd+412");
        
        bool adminResult1 = adminAuthController.SignOut(adminAuth1Id);
        bool adminResult2 = adminAuthController.SignOut(adminAuth2Id);

        // USER
        
        UserController userController = new UserController();
        userController.Save("user", "user@hotmail.com", "Pwd+1");
        userController.Save("user2", "user2@hotmail.com", "Pwd+2");

        UserAuthController userAuthController = new UserAuthController();
        int userAuth1Id = userAuthController.SignInWithUsername("user", "Pwd+1");
        int userAuth2Id = userAuthController.SignInWithEmail("user2@hotmail.com", "Pwd+2");

        bool userResult1 = userAuthController.SignOut(userAuth1Id);
        bool userResult2 = userAuthController.SignOut(userAuth2Id);
    }
}
