using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Exception.AdminException;
using ClothesRentalSystem.ConsoleUI.Exception.AuthException;
using ClothesRentalSystem.ConsoleUI.Exception.RentalException;
using ClothesRentalSystem.ConsoleUI.Exception.UserException;
using ClothesRentalSystem.ConsoleUI.Presentation;

namespace ClothesRentalSystem.ConsoleUI;

public static class FePrivateMenu
{
    public static void Open()
    {
        string hr = Program.HR;

        AdminController adminController = new AdminController();
        RentController rentController = new RentController();
        GiveBackController giveBackController = new GiveBackController();

        Console.WriteLine($"Private Menu");
        int choice = 0;
        while (choice != 8)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1. Promote User to Admin\n" +
                "2. Demote Admin to User\n" +
                "3. View All Admins\n" +
                "4. View Total Earnings\n" +
                "5. View Total Sales\n" +
                "6. View Admin Rental Decisions\n" +
                "7. View Admin Give Back Decisions\n" +
                "8. Return to Main Menu\n");

            Console.WriteLine($"{hr}\nYour choice : ");

            bool isValid = int.TryParse(Console.ReadLine(), out choice);

            if (!isValid || choice < 1 || choice > 8)
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
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is AdminAlreadyExistsException)
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
                    catch (System.Exception exception) when (
                        exception is AdminNotFoundException ||
                        exception is CannotModifySuperAdminRoleException ||
                        exception is UserAlreadyExistsException)
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
                    long totalSales = rentController.GetTotalSales();
                    Console.WriteLine($"Total Sales : {totalSales}");

                    break;
                case 6:
                    try
                    {
                        List<Rent> rentals = rentController.GetListByAdminDecision();
                        foreach (Rent rental in rentals)
                        {
                            Console.WriteLine(rental);
                        }
                    }
                    catch (System.Exception exception) when (
                        exception is AdminNotFoundException ||
                        exception is AdminOnlyAccessException ||
                        exception is NoRentalHistoryFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 7:
                    try
                    {
                        List<Rent> rentals = giveBackController.GetListByAdminDecision();
                        foreach (Rent rental in rentals)
                        {
                            Console.WriteLine(rental);
                        }
                    }
                    catch (System.Exception exception) when (
                        exception is AdminNotFoundException ||
                        exception is AdminOnlyAccessException ||
                        exception is NoRentalHistoryFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 8:
                    break;
            }
        }
    }
}
