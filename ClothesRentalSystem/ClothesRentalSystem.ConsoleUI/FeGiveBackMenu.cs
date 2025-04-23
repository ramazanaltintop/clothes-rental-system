using ClothesRentalSystem.ConsoleUI.Entity;
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
                    giveBackController.SendRequest(rentId, FeUserLogin.PeopleId);
                    break;
                case 2:
                    List<Rent> approvedOrRejectedRents = giveBackController.GetListByApprovedOrRejected(FeUserLogin.PeopleId);
                    foreach (Rent rent in approvedOrRejectedRents)
                    {
                        Console.WriteLine(rent);
                    }
                    break;
                case 3:
                    List<Rent> approvedRents = giveBackController.GetListByApproved(FeUserLogin.PeopleId);
                    foreach (Rent rent in approvedRents)
                    {
                        Console.WriteLine(rent);
                    }
                    break;
                case 4:
                    List<Rent> rejectedRents = giveBackController.GetListByRejected(FeUserLogin.PeopleId);
                    foreach (Rent rent in rejectedRents)
                    {
                        Console.WriteLine(rent);
                    }
                    break;
                case 5:
                    List<Rent> requestedRents = giveBackController.GetListByRequested(FeUserLogin.PeopleId);
                    foreach (Rent rent in requestedRents)
                    {
                        Console.WriteLine(rent);
                    }
                    break;
                case 6:
                    break;
            }
        }
    }
}
