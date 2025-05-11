using ClothesRentalSystem.Entity;
using ClothesRentalSystem.Exception.AuthException;
using ClothesRentalSystem.Exception.RentalException;
using ClothesRentalSystem.Exception.UserException;
using ClothesRentalSystem.Presentation;
using ClothesRentalSystem.Util;

namespace ClothesRentalSystem.ConsoleUI;

public static class FePrivateMenu
{
    public static void Open()
    {
        string hr = HR.Get();

        UserController userController = new UserController();
        RentController rentController = new RentController();
        ReturnController returnController = new ReturnController();

        Console.WriteLine($"{hr}\nPrivate Menu");
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
                "7. View Admin Return Decisions\n" +
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
                        userController.PromoteUserToAdmin(username);
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is SuperAdminAccessOnlyException ||
                        exception is UserAlreadyExistsException)
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
                        userController.DemoteAdminToUser(username);
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is SuperAdminAccessOnlyException ||
                        exception is CannotModifySuperAdminRoleException ||
                        exception is UserAlreadyExistsException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    Console.WriteLine($"{hr}\nThe role of {username} has been updated successfully.");

                    break;
                case 3:
                    try
                    {
                        List<User> users = userController.GetListByRole("ADMIN");
                        foreach (User user in users)
                        {
                            Console.WriteLine(user);
                        }
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is SuperAdminAccessOnlyException ||
                        exception is UsersNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
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
                        exception is UserNotFoundException ||
                        exception is SuperAdminAccessOnlyException ||
                        exception is RentalHistoryNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 7:
                    try
                    {
                        List<Rent> rentals = returnController.GetListByAdminDecision();
                        foreach (Rent rental in rentals)
                        {
                            Console.WriteLine(rental);
                        }
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is SuperAdminAccessOnlyException ||
                        exception is RentalHistoryNotFoundException)
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
