using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Exception.AdminException;
using ClothesRentalSystem.ConsoleUI.Exception.UserException;
using ClothesRentalSystem.ConsoleUI.Presentation;
using ClothesRentalSystem.ConsoleUI.Presentation.RentingController;

namespace ClothesRentalSystem.ConsoleUI;

public static class FePrivateMenu
{
    public static void Open()
    {
        string hr = Program.HR;

        AdminController adminController = new AdminController();
        RentController rentController = new RentController();

        Console.WriteLine($"Private Menu");
        int choice = 0;
        while (choice != 5)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1. Promote User to Admin\n" +
                "2. Demote Admin to User\n" +
                "3. View All Admins\n" +
                "4. View Total Earnings\n" +
                "5. Return to Main Menu\n");

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
                    Console.WriteLine($"{hr}\nWhich user do you want to make admin (username)");

                    string? username = Console.ReadLine();

                    if (username is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        adminController.PromoteUserToAdmin(username);
                    }
                    catch (UserNotFoundException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }
                    catch (AdminAlreadyExistsException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    Console.WriteLine($"{hr}\nThe role of {username} has been updated successfully.");

                    break;
                case 2:
                    Console.WriteLine($"{hr}\nWhich admin do you want to make user (username)");

                    username = Console.ReadLine();

                    if (username is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        adminController.DemoteAdminToUser(username);
                    }
                    catch (AdminNotFoundException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }
                    catch (CannotModifySuperAdminRoleException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }
                    catch(UserAlreadyExistsException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    Console.WriteLine($"{hr}\nThe role of {username} has been updated successfully.");

                    break;
                case 3:
                    List<Admin> admins = adminController.GetList();
                    foreach (Admin admin in admins)
                    {
                        Console.WriteLine(admin);
                    }
                    break;
                case 4:
                    decimal totalEarnings = rentController.GetTotalEarnings();
                    Console.WriteLine($"Total Earnings : ${totalEarnings}");

                    break;
                case 5:
                    break;
            }
        }
    }
}
