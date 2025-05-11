using ClothesRentalSystem.Exception.AuthException;
using ClothesRentalSystem.Presentation;
using ClothesRentalSystem.Util;

namespace ClothesRentalSystem.ConsoleUI;

public static class FeUserMenu
{
    public static void Open()
    {
        string hr = HR.Get();

        AuthController authController = new AuthController();

        Console.WriteLine($"{hr}\nUser Menu");
        int choice = 0;
        while (choice != 4)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1. Clothing Menu\n" +
                "2. Rental Menu\n" +
                "3. Manage Returns\n" +
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
                    FeReturnMenu.Open();

                    break;
                case 4:
                    try
                    {
                        authController.SignOut();
                        Console.WriteLine($"You have successfully signed out\n");
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
