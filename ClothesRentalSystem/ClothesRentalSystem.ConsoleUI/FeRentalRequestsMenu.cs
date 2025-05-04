using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Exception.AdminException;
using ClothesRentalSystem.ConsoleUI.Exception.AuthException;
using ClothesRentalSystem.ConsoleUI.Exception.ClothesException;
using ClothesRentalSystem.ConsoleUI.Exception.RentalException;
using ClothesRentalSystem.ConsoleUI.Exception.UserException;
using ClothesRentalSystem.ConsoleUI.Presentation;

namespace ClothesRentalSystem.ConsoleUI;

public static class FeRentalRequestsMenu
{
    public static void Open()
    {
        string hr = Program.HR;

        RentController rentController = new RentController();

        Console.WriteLine($"{hr}\nRental Requests Menu");

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1. View a User's Rental History\n" +
                "2. View Pending Rental Requests\n" +
                "3. Approve Rental Requests\n" +
                "4. Reject Rental Requests\n" +
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
                    Console.WriteLine($"{hr}\nWhich user's rentals history do you want to see (username)");

                    string? username = Console.ReadLine();

                    if (username is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        List<Rent> rents = rentController.GetListByUsername(username);
                        foreach (Rent rent in rents)
                        {
                            Console.WriteLine(rent);
                        }
                    }
                    catch (System.Exception exception) when (
                        exception is AdminNotFoundException ||
                        exception is AdminOnlyAccessException ||
                        exception is UserNotFoundException ||
                        exception is RentalNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 2:
                    try
                    {
                        List<Rent> requestedRents = rentController.GetListByPendingAll();
                        foreach (Rent rent in requestedRents)
                        {
                            Console.WriteLine(rent);
                        }
                    }
                    catch (System.Exception exception) when (
                        exception is AdminNotFoundException ||
                        exception is AdminOnlyAccessException ||
                        exception is NoPendingRentalRequestsException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 3:
                    Console.WriteLine($"{hr}\nWhich rental request do you want to approve (rentId)");

                    isValid = int.TryParse(Console.ReadLine(), out int rentId);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        rentController.ApproveRequest(rentId);
                    }
                    catch (System.Exception exception) when (
                        exception is AdminNotFoundException ||
                        exception is AdminOnlyAccessException ||
                        exception is RentalRequestNotFoundException ||
                        exception is RentalRequestAlreadyApprovedException ||
                        exception is RentalRequestAlreadyRejectedException ||
                        exception is ClothesNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 4:
                    Console.WriteLine($"{hr}\nWhich rental request do you want to reject (rentId)");

                    isValid = int.TryParse(Console.ReadLine(), out rentId);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        rentController.RejectRequest(rentId);
                    }
                    catch (System.Exception exception) when (
                        exception is AdminNotFoundException ||
                        exception is AdminOnlyAccessException ||
                        exception is RentalRequestNotFoundException ||
                        exception is RentalRequestAlreadyApprovedException ||
                        exception is RentalRequestAlreadyRejectedException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 5:
                    break;
            }
        }
    }
}
