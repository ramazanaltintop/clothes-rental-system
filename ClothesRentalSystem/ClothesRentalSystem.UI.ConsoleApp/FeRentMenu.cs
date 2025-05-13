using ClothesRentalSystem.Entity;
using ClothesRentalSystem.Exception.AuthException;
using ClothesRentalSystem.Exception.ClothingItemException;
using ClothesRentalSystem.Exception.RentalException;
using ClothesRentalSystem.Exception.UserException;
using ClothesRentalSystem.Presentation;
using ClothesRentalSystem.Util;

namespace ClothesRentalSystem.UI.ConsoleApp;

public static class FeRentMenu
{
    public static void Open()
    {
        string hr = HR.Get();

        RentController rentController = new RentController();
        ClothingItemController clothingItemController = new ClothingItemController();

        Console.WriteLine($"{hr}\nRental Menu");

        int choice = 0;

        while (choice != 9)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1. Add to Cart\n" +
                "2. View Cart\n" +
                "3. Clear Cart\n" +
                "4. Create Rental Request\n" +
                "5. View Past Rental Requests\n" +
                "6. View Approved Rental Requests\n" +
                "7. View Rejected Rental Requests\n" +
                "8. View Pending Rental Requests\n" +
                "9. Back to Previous Menu\n");

            Console.WriteLine($"{hr}\nYour choice : ");

            bool isValid = int.TryParse(Console.ReadLine(), out choice);

            if (!isValid || choice < 1 || choice > 9)
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

                    Console.WriteLine($"{hr}\nWhich clothing item would you like to rent : (clothingItemName)");
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
                        exception is UserAccessOnlyException ||
                        exception is ClothingItemNotFoundException ||
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
                        exception is UserAccessOnlyException ||
                        exception is EmptyCartException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 3:
                    try
                    {
                        rentController.ClearCart();
                        Console.WriteLine("Your cart successfully cleared.");
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is UserAccessOnlyException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 4:
                    try
                    {
                        rentController.SendRequest();
                        Console.WriteLine("Rental request sent.");
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is UserAccessOnlyException ||
                        exception is EmptyCartException ||
                        exception is ClothingItemNotFoundException ||
                        exception is OutOfStockException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 5:
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
                        exception is UserAccessOnlyException ||
                        exception is RentalHistoryNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 6:
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
                        exception is UserAccessOnlyException ||
                        exception is ApprovedRentalRequestsNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 7:
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
                        exception is UserAccessOnlyException ||
                        exception is RejectedRentalRequestsNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 8:
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
                        exception is UserAccessOnlyException ||
                        exception is PendingRentalRequestsNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 9:

                    break;
            }
        }
    }
}
