using ClothesRentalSystem.ConsoleUI.Presentation.AuthController;

namespace ClothesRentalSystem.ConsoleUI;

public static class FeUserMenu
{
    public static void OpenUserMenu()
    {
        string hr = Program.HR;

        UserAuthController userAuthController = new UserAuthController();

        Console.WriteLine($"Welcome");
        int choice = 0;
        while (choice != 4)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1_Clothing_Menu\n" +
                "2_Rental_Menu\n" +
                "3_Give_Back_Menu\n" +
                "4_Sign_Out\n");

            Console.WriteLine($"{hr}\nYour choice : ");

            bool isValid = int.TryParse(Console.ReadLine(), out choice);

            if (!isValid || choice < 1 || choice > 4)
            {
                Console.WriteLine($"{hr}\nInvalid input");
                continue;
            }

            switch (choice)
            {
                case 1:
                    FeClothingMenu.OpenClothingMenu();
                    break;
                case 2:
                    FeRentMenu.OpenRentMenu();
                    break;
                case 3:
                    FeGiveBackMenu.OpenGiveBackMenu();
                    break;
                case 4:
                    userAuthController.SignOut(FeUserLogin.PeopleId);
                    break;
            }
        }
    }
}
