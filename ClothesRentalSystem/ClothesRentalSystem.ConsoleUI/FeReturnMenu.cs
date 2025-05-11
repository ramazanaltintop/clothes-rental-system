using ClothesRentalSystem.Entity;
using ClothesRentalSystem.Exception.AuthException;
using ClothesRentalSystem.Exception.RentalException;
using ClothesRentalSystem.Exception.ReturnException;
using ClothesRentalSystem.Exception.UserException;
using ClothesRentalSystem.Presentation;
using ClothesRentalSystem.Util;

namespace ClothesRentalSystem.ConsoleUI;

public static class FeReturnMenu
{
    public static void Open()
    {
        string hr = HR.Get();

        ReturnController returnController = new ReturnController();

        Console.WriteLine($"{hr}\nReturn Menu");

        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1. Create Return Request\n" +
                "2. View Past Return Requests\n" +
                "3. View Approved Return Requests\n" +
                "4. View Rejected Return Requests\n" +
                "5. View Pending Return Requests\n" +
                "6. Back to Previous Menu\n");

            Console.WriteLine($"{hr}\nYour choice : ");

            bool isValid = int.TryParse(Console.ReadLine(), out choice);

            if (!isValid || choice < 1 || choice > 6)
            {
                Console.WriteLine($"{hr}\nInvalidInput");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine($"{hr}\nWhich rental would you like to return (ficheName)");

                    string? ficheName = Console.ReadLine();

                    if (ficheName is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        returnController.SendRequest(ficheName);
                        Console.WriteLine("Return request sended.");
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is UserAccessOnlyException ||
                        exception is RentalRequestNotFoundException ||
                        exception is ReturnRequestNotAllowedException ||
                        exception is ReturnRequestAlreadySentException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 2:
                    try
                    {
                        List<Rent> pastReturns = returnController.GetListByApprovedOrRejected();
                        foreach (Rent rent in pastReturns)
                        {
                            Console.WriteLine(rent);
                        }
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is UserAccessOnlyException ||
                        exception is ReturnHistoryNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 3:
                    try
                    {
                        List<Rent> approvedReturns = returnController.GetListByApproved();
                        foreach (Rent rent in approvedReturns)
                        {
                            Console.WriteLine(rent);
                        }
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is UserAccessOnlyException ||
                        exception is ApprovedReturnRequestsNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 4:
                    try
                    {
                        List<Rent> rejectedReturns = returnController.GetListByRejected();
                        foreach (Rent rent in rejectedReturns)
                        {
                            Console.WriteLine(rent);
                        }
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is UserAccessOnlyException ||
                        exception is RejectedReturnRequestsNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 5:
                    try
                    {
                        List<Rent> pendingReturns = returnController.GetListByPending();
                        foreach (Rent rent in pendingReturns)
                        {
                            Console.WriteLine(rent);
                        }
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is UserAccessOnlyException ||
                        exception is PendingReturnRequestsNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 6:

                    break;
            }
        }
    }
}
