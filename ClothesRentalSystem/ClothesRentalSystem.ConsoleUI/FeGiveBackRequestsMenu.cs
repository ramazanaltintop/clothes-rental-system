using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Exception.AdminException;
using ClothesRentalSystem.ConsoleUI.Exception.AuthException;
using ClothesRentalSystem.ConsoleUI.Exception.ClothesException;
using ClothesRentalSystem.ConsoleUI.Exception.GiveBackException;
using ClothesRentalSystem.ConsoleUI.Exception.RentalException;
using ClothesRentalSystem.ConsoleUI.Exception.UserException;
using ClothesRentalSystem.ConsoleUI.Presentation;

namespace ClothesRentalSystem.ConsoleUI;

public static class FeGiveBackRequestsMenu
{
    public static void Open()
    {
        string hr = Program.HR;

        GiveBackController giveBackController = new GiveBackController();

        Console.WriteLine($"{hr}\nGive Back Requests Menu");

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1. Approve Give Back Requests\n" +
                "2. Reject Give Back Requests\n" +
                "3. View a User's Give Back History\n" +
                "4. View Pending Give Back Requests\n" +
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
                    Console.WriteLine($"{hr}\nWhich give back request do you want to approve (rentId)");

                    isValid = int.TryParse(Console.ReadLine(), out int rentId);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        giveBackController.ApproveRequest(rentId);
                    }
                    catch (System.Exception exception) when (
                        exception is AdminNotFoundException ||
                        exception is AdminOnlyAccessException ||
                        exception is RentalRequestNotFoundException ||
                        exception is GiveBackRequestNotFoundException ||
                        exception is GiveBackRequestAlreadyApprovedException ||
                        exception is ClothesNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 2:
                    Console.WriteLine($"{hr}\nWhich give back request do you want to reject (rentId)");

                    isValid = int.TryParse(Console.ReadLine(), out rentId);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        giveBackController.RejectRequest(rentId);
                    }
                    catch (System.Exception exception) when (
                        exception is AdminNotFoundException ||
                        exception is AdminOnlyAccessException ||
                        exception is RentalRequestNotFoundException ||
                        exception is GiveBackRequestNotFoundException ||
                        exception is GiveBackRequestAlreadyRejectedException ||
                        exception is ClothesNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 3:
                    Console.WriteLine($"{hr}\nWhich user's give back history do you want to see (username)");

                    string? username = Console.ReadLine();

                    if (username is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        List<Rent> giveBacks = giveBackController.GetListByUsername(username);
                        foreach (Rent rent in giveBacks)
                        {
                            Console.WriteLine(rent);
                        }
                    }
                    catch (System.Exception exception) when (
                        exception is AdminNotFoundException ||
                        exception is AdminOnlyAccessException ||
                        exception is UserNotFoundException ||
                        exception is GiveBackNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 4:
                    try
                    {
                        List<Rent> pendingGiveBacks = giveBackController.GetListByPendingAll();
                        foreach (Rent rent in pendingGiveBacks)
                        {
                            Console.WriteLine(rent);
                        }
                    }
                    catch (System.Exception exception) when (
                        exception is AdminNotFoundException ||
                        exception is AdminOnlyAccessException ||
                        exception is NoPendingGiveBackRequestsException)
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
