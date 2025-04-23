using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Presentation;
using ClothesRentalSystem.ConsoleUI.Presentation.AuthController;
using ClothesRentalSystem.ConsoleUI.Presentation.RentingController;

namespace ClothesRentalSystem.ConsoleUI;

public static class FeAdminMenu
{
    public static void OpenAdminMenu()
    {
        string hr = Program.HR;

        ClothesController clothesController = new ClothesController();
        AdminAuthController adminAuthController = new AdminAuthController();
        RentController rentController = new RentController();
        GiveBackController giveBackController = new GiveBackController();
        
        Console.WriteLine($"{hr}\nAdmin Menu");

        int choice = 0;

        while (choice != 11)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1_Add_Clothing_Item\n" +
                "2_Remove_Clothing_Item\n" +
                "3_View_a_User's_Rental_History\n" +
                "4_View_Pending_Rental_Requests\n" +
                "5_Approve_Rental_Requests\n" +
                "6_Reject_Rental_Requests\n" +
                "7_Approve_Give_Back_Requests\n" +
                "8_Reject_Give_Back_Requests\n" +
                "9_View_a_User's_Give_Back_History\n" +
                "10_View_Pending_Give_Back_Requests\n" +
                "11_Sign_Out\n");

            Console.WriteLine($"{hr}\nYour choice : ");

            bool isValid = int.TryParse(Console.ReadLine(), out choice);

            if (!isValid || choice < 1 || choice > 11)
            {
                Console.WriteLine($"{hr}\nInvalid input");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine($"{hr}\nName : ");
                    string? name = Console.ReadLine();

                    if (name is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    Console.WriteLine($"{hr}\nPrice : ");

                    isValid = decimal.TryParse(Console.ReadLine(), out decimal price);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    Console.WriteLine($"{hr}\nStock count : ");

                    isValid = int.TryParse(Console.ReadLine(), out int stockCount);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    Console.WriteLine($"{hr}\nWhich category would you like to add it to (CategoryId)");

                    isValid = short.TryParse(Console.ReadLine(), out short categoryId);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    clothesController.Save(name, price, stockCount, categoryId, FeAdminLogin.PeopleId);
                    break;
                case 2:
                    Console.WriteLine($"{hr}\nWhich clothes do you want to delete (clothesId)");

                    isValid = int.TryParse(Console.ReadLine(), out int clothesId);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }
                    clothesController.Remove(clothesId, FeAdminLogin.PeopleId);
                    break;
                case 3:
                    Console.WriteLine($"{hr}\nWhich user's rentals history do you want to see (username)");

                    string? username = Console.ReadLine();

                    if (username is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    List<Rent> rents = rentController.GetListByUsername(username, FeAdminLogin.PeopleId);
                    foreach (Rent rent in rents)
                    {
                        Console.WriteLine(rent);
                    }
                    break;
                case 4:
                    List<Rent> requestedRents = rentController.GetListByRequestedAll(FeAdminLogin.PeopleId);
                    foreach (Rent rent in requestedRents)
                    {
                        Console.WriteLine(rent);
                    }
                    break;
                case 5:
                    Console.WriteLine($"{hr}\nWhich rental request do you want to approve (rentId)");

                    isValid = int.TryParse(Console.ReadLine(), out int rentId);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }
                    rentController.ApproveRequest(rentId, FeAdminLogin.PeopleId);
                    break;
                case 6:
                    Console.WriteLine($"{hr}\nWhich rental request do you want to reject (rentId)");

                    isValid = int.TryParse(Console.ReadLine(), out rentId);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }
                    rentController.RejectRequest(rentId, FeAdminLogin.PeopleId);
                    break;
                case 7:
                    Console.WriteLine($"{hr}\nWhich give back request do you want to approve (rentId)");

                    isValid = int.TryParse(Console.ReadLine(), out rentId);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }
                    giveBackController.ApproveRequest(rentId, FeAdminLogin.PeopleId);
                    break;
                case 8:
                    Console.WriteLine($"{hr}\nWhich give back request do you want to reject (rentId)");

                    isValid = int.TryParse(Console.ReadLine(), out rentId);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }
                    giveBackController.RejectRequest(rentId, FeAdminLogin.PeopleId);
                    break;
                case 9:
                    break;
                case 10:
                    break;
                case 11:
                    adminAuthController.SignOut(FeAdminLogin.PeopleId);
                    break;
            }
        }
    }
}
