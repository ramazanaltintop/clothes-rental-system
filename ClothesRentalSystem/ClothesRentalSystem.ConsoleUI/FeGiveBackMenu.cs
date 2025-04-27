using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Exception.AuthException;
using ClothesRentalSystem.ConsoleUI.Exception.GiveBackException;
using ClothesRentalSystem.ConsoleUI.Exception.RentalException;
using ClothesRentalSystem.ConsoleUI.Exception.UserException;
using ClothesRentalSystem.ConsoleUI.Presentation.RentingController;

namespace ClothesRentalSystem.ConsoleUI;

public static class FeGiveBackMenu
{
    public static void OpenGiveBackMenu()
    {
        string hr = Program.HR;

        GiveBackController giveBackController = new GiveBackController();

        Console.WriteLine($"{hr}\nGive Back Menu");

        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1_Create_Give_Back_Request\n" +
                "2_View_Past_Give_Back_Requests\n" +
                "3_View_Approved_Give_Back_Requests\n" +
                "4_View_Rejected_Give_Back_Requests\n" +
                "5_View_Pending_Give_Back_Requests\n" +
                "6_Back_to_Previous_Menu\n");

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
                        giveBackController.SendRequest(rentId, FeUserLogin.PeopleId);
                    }
                    catch (UserNotFoundException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }
                    catch (UserOnlyAccessException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }
                    catch (RentNotFoundException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }
                    catch (GiveBackRequestNotAllowedException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }
                    catch (GiveBackRequestAlreadySentException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 2:
                    try
                    {
                        List<Rent> approvedOrRejectedGiveBacks = giveBackController.GetListByApprovedOrRejected(FeUserLogin.PeopleId);
                        foreach (Rent rent in approvedOrRejectedGiveBacks)
                        {
                            Console.WriteLine(rent);
                        }
                    }
                    catch (UserNotFoundException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }
                    catch (UserOnlyAccessException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 3:
                    try
                    {
                        List<Rent> approvedGiveBacks = giveBackController.GetListByApproved(FeUserLogin.PeopleId);
                        foreach (Rent rent in approvedGiveBacks)
                        {
                            Console.WriteLine(rent);
                        }
                    }
                    catch (UserNotFoundException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }
                    catch (UserOnlyAccessException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 4:
                    try
                    {
                        List<Rent> rejectedGiveBacks = giveBackController.GetListByRejected(FeUserLogin.PeopleId);
                        foreach (Rent rent in rejectedGiveBacks)
                        {
                            Console.WriteLine(rent);
                        }
                    }
                    catch (UserNotFoundException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }
                    catch (UserOnlyAccessException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 5:
                    try
                    {
                        List<Rent> requestedGiveBacks = giveBackController.GetListByRequested(FeUserLogin.PeopleId);
                        foreach (Rent rent in requestedGiveBacks)
                        {
                            Console.WriteLine(rent);
                        }
                    }
                    catch (UserNotFoundException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }
                    catch (UserOnlyAccessException exception)
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
