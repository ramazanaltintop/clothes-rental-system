using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Exception.AdminException;
using ClothesRentalSystem.ConsoleUI.Exception.AuthException;
using ClothesRentalSystem.ConsoleUI.Exception.CategoryException;
using ClothesRentalSystem.ConsoleUI.Presentation;

namespace ClothesRentalSystem.ConsoleUI;

public static class FeCategoryMenu
{
    public static void Open()
    {
        string hr = Program.HR;

        CategoryController categoryController = new CategoryController();

        Console.WriteLine($"{hr}\nCategory Menu");

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1. Add Category\n" +
                "2. Remove Category\n" +
                "3. Update Category Name\n" +
                "4. View All Categories\n" +
                "5. Back to Previous Menu\n");

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
                    Console.WriteLine($"{hr}\nName : ");
                    string? name = Console.ReadLine();

                    if (name is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        categoryController.Save(name);
                    }
                    catch (System.Exception exception) when (
                        exception is AdminNotFoundException ||
                        exception is AdminAccessOnlyException ||
                        exception is CategoryAlreadyExistsException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 2:
                    Console.WriteLine($"{hr}\nWhich category do you want to delete (categoryName)");

                    name = Console.ReadLine();

                    if (name is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        categoryController.Remove(name);
                    }
                    catch (System.Exception exception) when (
                        exception is AdminNotFoundException ||
                        exception is AdminAccessOnlyException ||
                        exception is CategoryNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 3:
                    Console.WriteLine($"{hr}\nWhich category do you want to update (categoryName)");

                    string? oldCategoryName = Console.ReadLine();

                    if (oldCategoryName is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    Console.WriteLine($"{hr}\nNew category name : ");

                    string? newCategoryName = Console.ReadLine();

                    if (newCategoryName is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        categoryController.Update(oldCategoryName, newCategoryName);
                    }
                    catch (System.Exception exception) when (
                        exception is AdminNotFoundException ||
                        exception is AdminAccessOnlyException ||
                        exception is CategoryNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 4:
                    try
                    {
                        List<Category> categories = categoryController.GetList();
                        foreach (Category category in categories)
                        {
                            Console.WriteLine(category);
                        }
                    }
                    catch (CategoriesNotFoundException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 5:
                    break;
            }
        }
    }
}
