using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Exception.AuthException;
using ClothesRentalSystem.ConsoleUI.Exception.GiveBackException;
using ClothesRentalSystem.ConsoleUI.Exception.RentalException;
using ClothesRentalSystem.ConsoleUI.Exception.UserException;
using ClothesRentalSystem.ConsoleUI.Presentation;

namespace ClothesRentalSystem.ConsoleUI;

public static class FeGiveBackMenu
{
    public static void Open()
    {
        string hr = Program.HR;

        GiveBackController giveBackController = new GiveBackController();

        Console.WriteLine($"{hr}\nGive Back Menu");

        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1. Create Give Back Request\n" +
                "2. View Past Give Back Requests\n" +
                "3. View Approved Give Back Requests\n" +
                "4. View Rejected Give Back Requests\n" +
                "5. View Pending Give Back Requests\n" +
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
                    Console.WriteLine($"{hr}\nWhich rental would you like to give back (rentId)");

                    isValid = long.TryParse(Console.ReadLine(), out long rentId);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nInvalidInput");
                        continue;
                    }

                    try
                    {
                        giveBackController.SendRequest(rentId);
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is UserAccessOnlyException ||
                        exception is RentalRequestNotFoundException ||
                        exception is GiveBackRequestNotAllowedException ||
                        exception is GiveBackRequestAlreadySentException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 2:
                    try
                    {
                        List<Rent> approvedOrRejectedGiveBacks = giveBackController.GetListByApprovedOrRejected();
                        foreach (Rent rent in approvedOrRejectedGiveBacks)
                        {
                            Console.WriteLine(rent);
                        }
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is UserAccessOnlyException ||
                        exception is GiveBackHistoryNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 3:
                    try
                    {
                        List<Rent> approvedGiveBacks = giveBackController.GetListByApproved();
                        foreach (Rent rent in approvedGiveBacks)
                        {
                            Console.WriteLine(rent);
                        }
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is UserAccessOnlyException ||
                        exception is ApprovedGiveBackRequestsNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 4:
                    try
                    {
                        List<Rent> rejectedGiveBacks = giveBackController.GetListByRejected();
                        foreach (Rent rent in rejectedGiveBacks)
                        {
                            Console.WriteLine(rent);
                        }
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is UserAccessOnlyException ||
                        exception is RejectedGiveBackRequestsNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 5:
                    try
                    {
                        List<Rent> pendingGiveBacks = giveBackController.GetListByPending();
                        foreach (Rent rent in pendingGiveBacks)
                        {
                            Console.WriteLine(rent);
                        }
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is UserAccessOnlyException ||
                        exception is PendingGiveBackRequestsNotFoundException)
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
