using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Presentation;

namespace ClothesRentalSystem.ConsoleUI;

public static class FeClothesMenu
{
    public static void OpenClothesMenu()
    {
        string hr = Program.HR;

        ClothesController clothesController = new ClothesController();

        Console.WriteLine($"{hr}\nKiyafet Menusu");

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1_Kiyafet_Listesi\n" +
                "2_Kategoriye_Gore_Kiyafet_Listesi\n" +
                "3_Stogu_Olan_Kiyafetler\n" +
                "4_En_Cok_Kiralanan_Kiyafetler\n" +
                "5_Ust_Menu\n");

            Console.WriteLine($"{hr}\nSeciminiz : ");

            bool isValid = int.TryParse(Console.ReadLine(), out choice);

            if (!isValid || choice < 1 || choice > 5)
            {
                Console.WriteLine($"{hr}\nGecersiz giris");
                continue;
            }

            switch (choice)
            {
                case 1:
                    List<Clothes> clothes = clothesController.GetList();
                    foreach (Clothes cl in clothes)
                    {
                        Console.WriteLine(cl);
                    }
                    break;
                case 2:
                    Console.WriteLine($"{hr}\nHangi kategorideki kiyafetleri gormek istiyorsunuz (categoryName)");

                    string? categoryName = Console.ReadLine();

                    if (categoryName is null)
                    {
                        Console.WriteLine($"{hr}\nGecersiz giris");
                        continue;
                    }

                    List<Clothes> clothesByCategoryName = clothesController.GetListByCategoryName(categoryName);
                    foreach (Clothes cl in clothesByCategoryName)
                    {
                        Console.WriteLine(cl);
                    }
                    break;
                case 3:
                    List<Clothes> rentableClothes = clothesController.GetListByRentable();
                    foreach (Clothes cl in rentableClothes)
                    {
                        Console.WriteLine(cl);
                    }
                    break;
                case 4:
                    List<Clothes> mostRentedClothes = clothesController.GetListByMostRented();
                    foreach (Clothes cl in mostRentedClothes)
                    {
                        Console.WriteLine(cl);
                    }
                    break;
                case 5:
                    break;
            }
        }
    }
}