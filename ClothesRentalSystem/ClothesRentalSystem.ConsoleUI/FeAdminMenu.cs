using ClothesRentalSystem.ConsoleUI.Exception.AuthException;
using ClothesRentalSystem.ConsoleUI.Exception.UserException;
using ClothesRentalSystem.ConsoleUI.Presentation;

namespace ClothesRentalSystem.ConsoleUI;

public static class FeAdminMenu
{
    public static void Open()
    {
        string hr = Program.HR;

        AuthController authController = new AuthController();

        Console.WriteLine($"{hr}\nAdmin Menu");

        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1. Categories Menu\n" +
                "2. Clothing Menu\n" +
                "3. Rental Requests Menu\n" +
                "4. Return Requests Menu\n" +
                "5. Private Menu\n" +
                "6. Sign Out\n");

            Console.WriteLine($"{hr}\nYour choice : ");

            bool isValid = int.TryParse(Console.ReadLine(), out choice);

            if (!isValid || choice < 1 || choice > 6)
            {
                Console.WriteLine($"{hr}\nInvalid input");
                continue;
            }

            switch (choice)
            {
                case 1:
                    FeCategoryMenu.Open();

                    break;
                case 2:
                    FeClothingManagementMenu.Open();

                    break;
                case 3:
                    FeRentalRequestsMenu.Open();

                    break;
                case 4:
                    FeReturnRequestsMenu.Open();

                    break;
                case 5:
                    try
                    {
                        authController.HasSuperAdmin();
                        FePrivateMenu.Open();
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is SuperAdminAccessOnlyException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 6:
                    try
                    {
                        authController.SignOut();
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
