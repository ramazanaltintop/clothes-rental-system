using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Exception.AuthException;
using ClothesRentalSystem.ConsoleUI.Exception.ClothesException;
using ClothesRentalSystem.ConsoleUI.Exception.RentalException;
using ClothesRentalSystem.ConsoleUI.Exception.UserException;
using ClothesRentalSystem.ConsoleUI.Presentation;
using ClothesRentalSystem.ConsoleUI.Presentation.RentingController;

namespace ClothesRentalSystem.ConsoleUI;

public static class FeRentMenu
{
    public static void Open()
    {
        string hr = Program.HR;

        RentController rentController = new RentController();
        ClothesController clothesController = new ClothesController();

        Console.WriteLine($"{hr}\nRental Menu");

        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1. Create Rental Request\n" +
                "2. View Past Rental Requests\n" +
                "3. View Approved Rental Requests\n" +
                "4. View Rejected Rental Requests\n" +
                "5. View Pending Rental Requests\n" +
                "6. Back to Previous Menu\n");

            Console.WriteLine($"{hr}\nYour choice : ");

            bool isValid = int.TryParse(Console.ReadLine(), out choice);

            if (!isValid || choice < 1 || choice > 6)
            {
                Console.WriteLine($"{hr}\nInvalid input");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine($"{hr}\nDay : ");
                    isValid = byte.TryParse(Console.ReadLine(), out byte day);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    Console.WriteLine($"{hr}\nQuantity : ");
                    isValid = byte.TryParse(Console.ReadLine(), out byte quantity);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    Console.WriteLine($"{hr}\nWhich clothes would you like to rent : (clothesId)");
                    isValid = long.TryParse(Console.ReadLine(), out long clothesId);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        clothesController.GetById(clothesId);
                        rentController.SendRequest(day, quantity, clothesId, FeUserSignInMenu.PeopleId);
                    }
                    catch (ClothesNotFoundException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
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
                    catch (OutOfStockException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 2:
                    try
                    {
                        List<Rent> approvedOrRejectedRents = rentController.GetListByApprovedOrRejected(FeUserSignInMenu.PeopleId);
                        foreach (Rent rent in approvedOrRejectedRents)
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
                    catch (NoRentalHistoryFoundException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 3:
                    try
                    {
                        List<Rent> approvedRents = rentController.GetListByApproved(FeUserSignInMenu.PeopleId);
                        foreach (Rent rent in approvedRents)
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
                    catch (NoApprovedRentalRequestsException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 4:
                    try
                    {
                        List<Rent> rejectedRents = rentController.GetListByRejected(FeUserSignInMenu.PeopleId);
                        foreach (Rent rent in rejectedRents)
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
                    catch (NoRejectedRentalRequestsException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 5:
                    try
                    {
                        List<Rent> pendingRents = rentController.GetListByPending(FeUserSignInMenu.PeopleId);
                        foreach (Rent rent in pendingRents)
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
                    catch (NoPendingRentalRequestsException exception)
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
