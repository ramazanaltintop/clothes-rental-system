using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Exception.AdminException;
using ClothesRentalSystem.ConsoleUI.Exception.AuthException;
using ClothesRentalSystem.ConsoleUI.Exception.CategoryException;
using ClothesRentalSystem.ConsoleUI.Exception.ClothingItemException;
using ClothesRentalSystem.ConsoleUI.Presentation;

namespace ClothesRentalSystem.ConsoleUI;

public static class FeClothingManagementMenu
{
    public static void Open()
    {
        string hr = Program.HR;

        ClothingItemController clothingItemController = new ClothingItemController();

        Console.WriteLine($"{hr}\nClothing Menu");

        int choice = 0;

        while (choice != 7)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1. Add Clothing Item\n" +
                "2. Remove Clothing Item\n" +
                "3. Update Clothing Name and Price\n" +
                "4. Update Clothing Category\n" +
                "5. Update Clothing Stock\n" +
                "6. View All Clothing Items\n" +
                "7. Return to Main Menu\n");

            Console.WriteLine($"{hr}\nYour choice : ");

            bool isValid = int.TryParse(Console.ReadLine(), out choice);

            if (!isValid || choice < 1 || choice > 7)
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

                    Console.WriteLine($"{hr}\nWhich category would you like to add it to (categoryName)");

                    string? categoryName = Console.ReadLine();

                    if (categoryName is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        clothingItemController.Save(name, price, stockCount, categoryName);
                    }
                    catch (System.Exception exception) when (
                        exception is AdminNotFoundException ||
                        exception is AdminAccessOnlyException ||
                        exception is ClothingItemAlreadyExistsException ||
                        exception is NegativeStockValueException ||
                        exception is NegativePriceException ||
                        exception is CategoryNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 2:
                    Console.WriteLine($"{hr}\nWhich clothing item do you want to delete (clothingItemName)");

                    name = Console.ReadLine();

                    if (name is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        clothingItemController.Remove(name);
                    }
                    catch (System.Exception exception) when (
                        exception is AdminNotFoundException ||
                        exception is AdminAccessOnlyException ||
                        exception is ClothingItemNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 3:
                    Console.WriteLine($"{hr}\nWhich clothing item do you want to update (clothingItemName)");

                    name = Console.ReadLine();

                    if (name is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    Console.WriteLine($"{hr}\nNew clothing item name : ");
                    string? newName = Console.ReadLine();

                    if (newName is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    Console.WriteLine($"{hr}\nPrice : ");

                    isValid = decimal.TryParse(Console.ReadLine(), out price);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        clothingItemController.Update(name, newName, price);
                    }
                    catch (System.Exception exception) when (
                        exception is AdminNotFoundException ||
                        exception is AdminAccessOnlyException ||
                        exception is NegativePriceException ||
                        exception is ClothingItemNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 4:
                    Console.WriteLine($"{hr}\nWhich clothing item do you want to update (clothingItemName)");

                    name = Console.ReadLine();

                    if (name is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    Console.WriteLine($"{hr}\nWhich category would you like to add it to (categoryName)");

                    categoryName = Console.ReadLine();

                    if (categoryName is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        clothingItemController.Update(name, categoryName);
                    }
                    catch (System.Exception exception) when (
                        exception is AdminNotFoundException ||
                        exception is AdminAccessOnlyException ||
                        exception is CategoryNotFoundException ||
                        exception is ClothingItemNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 5:
                    Console.WriteLine($"{hr}\nWhich clothing item do you want to update (clothingItemName)");

                    name = Console.ReadLine();

                    if (name is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    Console.WriteLine($"{hr}\nStock count : ");

                    isValid = int.TryParse(Console.ReadLine(), out stockCount);

                    if (!isValid)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        clothingItemController.Update(name, stockCount);
                    }
                    catch (System.Exception exception) when (
                        exception is AdminNotFoundException ||
                        exception is AdminAccessOnlyException ||
                        exception is NegativeStockValueException ||
                        exception is ClothingItemNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 6:
                    try
                    {
                        List<ClothingItem> clothes = clothingItemController.GetList();
                        foreach (ClothingItem cl in clothes)
                        {
                            Console.WriteLine(cl);
                        }
                    }
                    catch (ClothingItemsNotFoundException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 7:
                    break;
            }
        }
    }
}
