using ClothesRentalSystem.ConsoleUI.Exception.AdminException;
using ClothesRentalSystem.ConsoleUI.Exception.AuthException;
using ClothesRentalSystem.ConsoleUI.Presentation.AuthController;

namespace ClothesRentalSystem.ConsoleUI;

public static class FeAdminMenu
{
    public static void Open()
    {
        string hr = Program.HR;

        AdminAuthController adminAuthController = new AdminAuthController();

        Console.WriteLine($"{hr}\nAdmin Menu");

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1. Clothing Management Menu\n" +
                "2. Rental Requests Menu\n" +
                "3. Give Back Requests Menu\n" +
                "4. Private Menu\n" +
                "5. Sign Out\n");

            Console.WriteLine($"{hr}\nYour choice : ");

            bool isValid = int.TryParse(Console.ReadLine(), out choice);

            if (!isValid || choice < 1 || choice > 5)
            {
                Console.WriteLine($"{hr}\nInvalid input");
                continue;
            }

            switch (choice)
            {
                case 1:
                    FeClothingManagementMenu.Open();
                    break;
                case 2:
                    FeRentalRequestsMenu.Open();
                    break;
                case 3:
                    FeGiveBackRequestsMenu.Open();
                    break;
                case 4:
                    try
                    {
                        adminAuthController.HasSuperAdmin(FeAdminSignInMenu.PeopleId);
                        FePrivateMenu.Open();
                    }
                    catch (AdminNotFoundException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }
                    catch (RequireSuperAdminRoleException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 5:
                    try
                    {
                        adminAuthController.SignOut(FeAdminSignInMenu.PeopleId);
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
