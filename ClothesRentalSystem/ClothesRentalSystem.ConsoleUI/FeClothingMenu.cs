using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Exception.CategoryException;
using ClothesRentalSystem.ConsoleUI.Exception.ClothesException;
using ClothesRentalSystem.ConsoleUI.Presentation;

namespace ClothesRentalSystem.ConsoleUI;

public static class FeClothingMenu
{
    public static void Open()
    {
        string hr = Program.HR;

        ClothesController clothesController = new ClothesController();
        CategoryController categoryController = new CategoryController();

        Console.WriteLine($"{hr}\nClothing Menu");

        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1. View All Clothes\n" +
                "2. View All Categories\n" +
                "3. View Clothes by Category\n" +
                "4. View Available Clothes\n" +
                "5. View Most Rented Clothes\n" +
                "6. Back to Previous Menu\n");

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
                    List<Clothes> clothes = clothesController.GetList();
                    foreach (Clothes cl in clothes)
                    {
                        Console.WriteLine(cl);
                    }

                    break;
                case 2:
                    List<Category> categories = categoryController.GetList();
                    foreach (Category category in categories)
                    {
                        Console.WriteLine(category);
                    }

                    break;
                case 3:
                    Console.WriteLine($"{hr}\nWhich category of clothes do you want to see(categoryName)");

                    string? categoryName = Console.ReadLine();

                    if (categoryName is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        List<Clothes> clothesByCategoryName = clothesController.GetListByCategoryName(categoryName);
                        foreach (Clothes cl in clothesByCategoryName)
                        {
                            Console.WriteLine(cl);
                        }
                    }
                    catch (System.Exception exception) when (
                        exception is CategoryNotFoundException ||
                        exception is NoClothesInCategoryException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 4:
                    List<Clothes> rentableClothes = clothesController.GetListByRentable();
                    foreach (Clothes cl in rentableClothes)
                    {
                        Console.WriteLine(cl);
                    }

                    break;
                case 5:
                    try
                    {
                        List<Clothes> mostRentedClothes = clothesController.GetListByMostRented();
                        foreach (Clothes cl in mostRentedClothes)
                        {
                            Console.WriteLine(cl);
                        }
                    }
                    catch (NoRentedClothesFoundException exception)
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