using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Exception.AuthException;
using ClothesRentalSystem.ConsoleUI.Exception.ClothesException;
using ClothesRentalSystem.ConsoleUI.Exception.UserException;
using ClothesRentalSystem.ConsoleUI.Presentation;
using ClothesRentalSystem.ConsoleUI.Presentation.RentingController;

namespace ClothesRentalSystem.ConsoleUI;

public static class FeRentMenu
{
    public static void OpenRentMenu()
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
                "1_Create_Rental_Request\n" +
                "2_View_Past_Rental_Requests\n" +
                "3_View_Approved_Rental_Requests\n" +
                "4_View_Rejected_Rental_Requests\n" +
                "5_View_Pending_Rental_Requests\n" +
                "6_Back_to_Previous_Menu\n");

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
                        rentController.SendRequest(day, quantity, clothesId, FeUserLogin.PeopleId);
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
                        List<Rent> approvedOrRejectedRents = rentController.GetListByApprovedOrRejected(FeUserLogin.PeopleId);
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

                    break;
                case 3:
                    try
                    {
                        List<Rent> approvedRents = rentController.GetListByApproved(FeUserLogin.PeopleId);
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

                    break;
                case 4:
                    try
                    {
                        List<Rent> rejectedRents = rentController.GetListByRejected(FeUserLogin.PeopleId);
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

                    break;
                case 5:
                    try
                    {
                        List<Rent> requestedRents = rentController.GetListByRequested(FeUserLogin.PeopleId);
                        foreach (Rent rent in requestedRents)
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
