using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Exception.AuthException;
using ClothesRentalSystem.ConsoleUI.Exception.ClothesException;
using ClothesRentalSystem.ConsoleUI.Exception.RentalException;
using ClothesRentalSystem.ConsoleUI.Exception.UserException;
using ClothesRentalSystem.ConsoleUI.Presentation;

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

        while (choice != 8)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1. Add to Cart\n" +
                "2. View Cart\n" +
                "3. Create Rental Request\n" +
                "4. View Past Rental Requests\n" +
                "5. View Approved Rental Requests\n" +
                "6. View Rejected Rental Requests\n" +
                "7. View Pending Rental Requests\n" +
                "8. Back to Previous Menu\n");

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

                    Console.WriteLine($"{hr}\nWhich clothes would you like to rent : (clothesName)");
                    string? name = Console.ReadLine();

                    if (name is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        rentController.AddToCart(day, quantity, name);
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is UserOnlyAccessException ||
                        exception is ClothesNotFoundException ||
                        exception is OutOfStockException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 2:
                    try
                    {
                        List<CartItem> items = rentController.GetCart();
                        foreach (CartItem item in items)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is UserOnlyAccessException ||
                        exception is EmptyCartException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 3:
                    try
                    {
                        rentController.SendRequest();
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is UserOnlyAccessException ||
                        exception is EmptyCartException ||
                        exception is ClothesNotFoundException ||
                        exception is OutOfStockException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 4:
                    try
                    {
                        List<Rent> approvedOrRejectedRents = rentController.GetListByApprovedOrRejected();
                        foreach (Rent rent in approvedOrRejectedRents)
                        {
                            Console.WriteLine(rent);
                        }
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is UserOnlyAccessException ||
                        exception is NoRentalHistoryFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 5:
                    try
                    {
                        List<Rent> approvedRents = rentController.GetListByApproved();
                        foreach (Rent rent in approvedRents)
                        {
                            Console.WriteLine(rent);
                        }
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is UserOnlyAccessException ||
                        exception is NoApprovedRentalRequestsException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 6:
                    try
                    {
                        List<Rent> rejectedRents = rentController.GetListByRejected();
                        foreach (Rent rent in rejectedRents)
                        {
                            Console.WriteLine(rent);
                        }
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is UserOnlyAccessException ||
                        exception is NoRejectedRentalRequestsException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 7:
                    try
                    {
                        List<Rent> pendingRents = rentController.GetListByPending();
                        foreach (Rent rent in pendingRents)
                        {
                            Console.WriteLine(rent);
                        }
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is UserOnlyAccessException ||
                        exception is NoPendingRentalRequestsException)
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
