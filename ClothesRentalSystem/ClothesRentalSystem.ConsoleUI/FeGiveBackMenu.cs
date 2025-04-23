using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Presentation.RentingController;

namespace ClothesRentalSystem.ConsoleUI;

public static class FeGiveBackMenu
{
    public static void OpenGiveBackMenu()
    {
        string hr = Program.HR;

        GiveBackController giveBackController = new GiveBackController();

        Console.WriteLine($"{hr}\nKiyafet Iade Menusu");

        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1_Kiyafet_Iade_Talebi\n" +
                "2_Gecmis_Iade_Istekleri\n" +
                "3_Onaylanan_Iade_Istekleri\n" +
                "4_Onaylanmayan_Iade_Istekleri\n" +
                "5_Bekleyen_Iade_Istekleri\n" +
                "6_Ust_Menu\n");

            Console.WriteLine($"{hr}\nSeciminiz : ");

            bool isValid = int.TryParse(Console.ReadLine(), out choice);

            if (!isValid || choice < 1 || choice > 6)
            {
                Console.WriteLine($"{hr}\nGecersiz giris");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine($"{hr}\nHangi no'lu kiralamanizi iade etmek istiyorsunuz (rentId)");

                    isValid = long.TryParse(Console.ReadLine(), out long rentId);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nGecersiz giris");
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
