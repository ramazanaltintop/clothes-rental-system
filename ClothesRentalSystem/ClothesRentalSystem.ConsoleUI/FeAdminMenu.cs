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
        
        Console.WriteLine($"{hr}\nKiyafet Menusu");

        int choice = 0;

        while (choice != 9)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1_Kiyafet_Ekle\n" +
                "2_Kiyafet_Sil\n" +
                "3_Bir_Kullanicinin_Gecmis_Kiralamalarini_Goruntule\n" +
                "4_Bekleyen_Kiralama_Taleplerini_Goruntule\n" +
                "5_Kiralama_Taleplerini_Onayla\n" +
                "6_Kiralama_Taleplerini_Reddet\n" +
                "7_Iade_Taleplerini_Onayla\n" +
                "8_Iade_Taleplerini_Reddet\n" +
                "9_Oturumu_Kapat\n");

            Console.WriteLine($"{hr}\nSeciminiz : ");

            bool isValid = int.TryParse(Console.ReadLine(), out choice);

            if (!isValid || choice < 1 || choice > 9)
            {
                Console.WriteLine($"{hr}\nGecersiz giris");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine($"{hr}\nKiyafetin adini giriniz : ");
                    string? name = Console.ReadLine();

                    if (name is null)
                    {
                        Console.WriteLine($"{hr}\nGecersiz giris");
                        continue;
                    }

                    Console.WriteLine($"{hr}\nKiyafetin fiyatini giriniz : ");

                    isValid = decimal.TryParse(Console.ReadLine(), out decimal price);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nGecersiz giris");
                        continue;
                    }

                    Console.WriteLine($"{hr}\nKac adet eklemek istiyorsunuz?");

                    isValid = int.TryParse(Console.ReadLine(), out int stockCount);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nGecersiz giris");
                        continue;
                    }

                    Console.WriteLine($"{hr}\nHangi kategoriye eklemek istiyorsunuz? (CategoryId)");

                    isValid = short.TryParse(Console.ReadLine(), out short categoryId);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nGecersiz giris");
                        continue;
                    }

                    clothesController.Save(name, price, stockCount, categoryId, FeAdminLogin.PeopleId);
                    break;
                case 2:
                    Console.WriteLine($"{hr}\nHangi kiyafeti silmek istiyorsunuz (clothesId)");

                    isValid = int.TryParse(Console.ReadLine(), out int clothesId);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nGecersiz giris");
                        continue;
                    }
                    clothesController.Remove(clothesId, FeAdminLogin.PeopleId);
                    break;
                case 3:
                    Console.WriteLine($"{hr}\nHangi kullanicinin gecmis kiralamalarini gormek istiyorsunuz (username)");

                    string? username = Console.ReadLine();

                    if (username is null)
                    {
                        Console.WriteLine($"{hr}\nGecersiz giris");
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
                    Console.WriteLine($"{hr}\nHangi kiralama talebini onaylamak istiyorsunuz (rentId)");

                    isValid = int.TryParse(Console.ReadLine(), out int rentId);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nGecersiz giris");
                        continue;
                    }
                    rentController.ApproveRequest(rentId, FeAdminLogin.PeopleId);
                    break;
                case 6:
                    Console.WriteLine($"{hr}\nHangi kiralama talebini reddetmek istiyorsunuz (rentId)");

                    isValid = int.TryParse(Console.ReadLine(), out rentId);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nGecersiz giris");
                        continue;
                    }
                    rentController.RejectRequest(rentId, FeAdminLogin.PeopleId);
                    break;
                case 7:
                    Console.WriteLine($"{hr}\nHangi iade talebini onaylamak istiyorsunuz (rentId)");

                    isValid = int.TryParse(Console.ReadLine(), out rentId);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nGecersiz giris");
                        continue;
                    }
                    giveBackController.ApproveRequest(rentId, FeAdminLogin.PeopleId);
                    break;
                case 8:
                    Console.WriteLine($"{hr}\nHangi iade talebini reddetmek istiyorsunuz (rentId)");

                    isValid = int.TryParse(Console.ReadLine(), out rentId);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nGecersiz giris");
                        continue;
                    }
                    giveBackController.RejectRequest(rentId, FeAdminLogin.PeopleId);
                    break;
                case 9:
                    adminAuthController.SignOut(FeAdminLogin.PeopleId);
                    break;
            }
        }
    }
}
