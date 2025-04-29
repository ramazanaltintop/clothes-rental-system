using ClothesRentalSystem.ConsoleUI.Exception.AuthException;
using ClothesRentalSystem.ConsoleUI.Presentation.AuthController;

namespace ClothesRentalSystem.ConsoleUI;

public static class FeUserMenu
{
    public static void Open()
    {
        string hr = Program.HR;

        UserAuthController userAuthController = new UserAuthController();

        Console.WriteLine($"User Menu");
        int choice = 0;
        while (choice != 4)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1. Clothing Menu\n" +
                "2. Rental Menu\n" +
                "3. Give Back Menu\n" +
                "4. Sign Out\n");

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
                    FeClothingMenu.Open();
                    break;
                case 2:
                    FeRentMenu.Open();
                    break;
                case 3:
                    FeGiveBackMenu.Open();
                    break;
                case 4:
                    try
                    {
                        userAuthController.SignOut(FeUserSignInMenu.PeopleId);
                    }
                    catch (NotAuthenticatedException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }
                    break;
            }
        }
    }
}
