using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Presentation;

namespace ClothesRentalSystem.ConsoleUI;

public static class FeClothingMenu
{
    public static void OpenClothingMenu()
    {
        string hr = Program.HR;

        ClothesController clothesController = new ClothesController();

        Console.WriteLine($"{hr}\nClothing Menu");

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1_View_All_Clothes\n" +
                "2_View_Clothes_by_Category\n" +
                "3_View_Available_Clothes\n" +
                "4_View_Most_Rented_Clothes\n" +
                "5_Back_to_Previous_Menu\n");

            Console.WriteLine($"{hr}\nYour choice : ");

            bool isValid = int.TryParse(Console.ReadLine(), out choice);

            if (!isValid || choice < 1 || choice > 5)
            {
                Console.WriteLine($"{hr}\nInvalid input");
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
                    Console.WriteLine($"{hr}\nWhich category of clothes do you want to see(categoryName)");

                    string? categoryName = Console.ReadLine();

                    if (categoryName is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
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