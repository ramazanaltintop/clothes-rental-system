using ClothesRentalSystem.Entity;
using ClothesRentalSystem.Exception.AuthException;
using ClothesRentalSystem.Exception.ClothingItemException;
using ClothesRentalSystem.Exception.RentalException;
using ClothesRentalSystem.Exception.UserException;
using ClothesRentalSystem.Presentation;
using ClothesRentalSystem.Util;

namespace ClothesRentalSystem.ConsoleUI;

public static class FeRentalRequestsMenu
{
    public static void Open()
    {
        string hr = HR.Get();

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
                        exception is UserNotFoundException ||
                        exception is AdminAccessOnlyException ||
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
                        exception is UserNotFoundException ||
                        exception is AdminAccessOnlyException ||
                        exception is PendingRentalRequestsNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 3:
                    Console.WriteLine($"{hr}\nWhich rental request do you want to approve (ficheName)");

                    string? ficheName = Console.ReadLine();

                    if (ficheName is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        rentController.ApproveRequest(ficheName);
                        Console.WriteLine("Rental request approved.");
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is AdminAccessOnlyException ||
                        exception is RentalRequestNotFoundException ||
                        exception is RentalRequestAlreadyApprovedException ||
                        exception is RentalRequestAlreadyRejectedException ||
                        exception is ClothingItemNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 4:
                    Console.WriteLine($"{hr}\nWhich rental request do you want to reject (ficheName)");

                    ficheName = Console.ReadLine();

                    if (ficheName is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        rentController.RejectRequest(ficheName);
                        Console.WriteLine("Rental request rejected.");
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is AdminAccessOnlyException ||
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
