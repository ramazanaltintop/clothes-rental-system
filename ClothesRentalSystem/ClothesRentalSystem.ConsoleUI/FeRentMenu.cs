using ClothesRentalSystem.ConsoleUI.Entity;
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

        Console.WriteLine($"{hr}\nKiralama Menusu");

        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1_Kiyafet_Kiralama_Talebi\n" +
                "2_Gecmis_Kiralama_Istekleri\n" +
                "3_Onaylanan_Kiralama_Istekleri\n" +
                "4_Onaylanmayan_Kiralama_Istekleri\n" +
                "5_Bekleyen_Kiralama_Istekleri\n" +
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
                    Console.WriteLine($"{hr}\nKac gun kiralamak istiyorsunuz : ");
                    isValid = byte.TryParse(Console.ReadLine(), out byte day);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nGecersiz giris");
                        continue;
                    }

                    Console.WriteLine($"{hr}\nKac tane kiralamak istiyorsunuz : ");
                    isValid = byte.TryParse(Console.ReadLine(), out byte quantity);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nGecersiz giris");
                        continue;
                    }

                    Console.WriteLine($"{hr}\nKac no'lu kiyafeti kiralamak istiyorsunuz : ");
                    isValid = long.TryParse(Console.ReadLine(), out long clothesId);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nGecersiz giris");
                        continue;
                    }

                    clothesController.GetById(clothesId);

                    rentController.SendRequest(day, quantity, clothesId, FeUserLogin.PeopleId);
                    break;
                case 2:
                    List<Rent> approvedOrRejectedRents = rentController.GetListByApprovedOrRejected(FeUserLogin.PeopleId);
                    foreach (Rent rent in approvedOrRejectedRents)
                    {
                        Console.WriteLine(rent);
                    }
                    break;
                case 3:
                    List<Rent> approvedRents = rentController.GetListByApproved(FeUserLogin.PeopleId);
                    foreach (Rent rent in approvedRents)
                    {
                        Console.WriteLine(rent);
                    }
                    break;
                case 4:
                    List<Rent> rejectedRents = rentController.GetListByRejected(FeUserLogin.PeopleId);
                    foreach (Rent rent in rejectedRents)
                    {
                        Console.WriteLine(rent);
                    }
                    break;
                case 5:
                    List<Rent> requestedRents = rentController.GetListByRequested(FeUserLogin.PeopleId);
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
