using ClothesRentalSystem.Entity;
using ClothesRentalSystem.Exception.AuthException;
using ClothesRentalSystem.Exception.ClothingItemException;
using ClothesRentalSystem.Exception.RentalException;
using ClothesRentalSystem.Exception.ReturnException;
using ClothesRentalSystem.Exception.UserException;
using ClothesRentalSystem.Presentation;
using ClothesRentalSystem.Util;

namespace ClothesRentalSystem.UI.ConsoleApp;

public static class FeReturnRequestsMenu
{
    public static void Open()
    {
        string hr = HR.Get();

        ReturnController returnController = new ReturnController();

        Console.WriteLine($"{hr}\nReturn Requests Menu");

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1. Approve Return Requests\n" +
                "2. Reject Return Requests\n" +
                "3. View a User's Return History\n" +
                "4. View Pending Return Requests\n" +
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
                    Console.WriteLine($"{hr}\nWhich return request do you want to approve (ficheName)");

                    string? ficheName = Console.ReadLine();

                    if (ficheName is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        returnController.ApproveRequest(ficheName);
                        Console.WriteLine("Return request approved.");
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is AdminAccessOnlyException ||
                        exception is RentalRequestNotFoundException ||
                        exception is ReturnRequestNotFoundException ||
                        exception is ReturnRequestAlreadyApprovedException ||
                        exception is ClothingItemNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 2:
                    Console.WriteLine($"{hr}\nWhich return request do you want to reject (ficheName)");

                    ficheName = Console.ReadLine();

                    if (ficheName is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        returnController.RejectRequest(ficheName);
                        Console.WriteLine("Return request rejected.");
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is AdminAccessOnlyException ||
                        exception is RentalRequestNotFoundException ||
                        exception is ReturnRequestNotFoundException ||
                        exception is ReturnRequestAlreadyRejectedException ||
                        exception is ClothingItemNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 3:
                    Console.WriteLine($"{hr}\nWhich user's return history do you want to see (username)");

                    string? username = Console.ReadLine();

                    if (username is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        List<Rent> userReturns = returnController.GetListByUsername(username);
                        foreach (Rent rent in userReturns)
                        {
                            Console.WriteLine(rent);
                        }
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is AdminAccessOnlyException ||
                        exception is UserNotFoundException ||
                        exception is ReturnNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 4:
                    try
                    {
                        List<Rent> pendingReturns = returnController.GetListByPendingAll();
                        foreach (Rent rent in pendingReturns)
                        {
                            Console.WriteLine(rent);
                        }
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is AdminAccessOnlyException ||
                        exception is PendingReturnRequestsNotFoundException)
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
