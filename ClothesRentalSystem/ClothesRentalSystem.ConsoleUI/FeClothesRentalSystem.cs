using ClothesRentalSystem.ConsoleUI.Exception.UserException;
using ClothesRentalSystem.ConsoleUI.Presentation;

namespace ClothesRentalSystem.ConsoleUI;

public static class FeClothesRentalSystem
{
    public static void StartProgram()
    {
        string hr = Program.HR;

        UserController userController = new UserController();

        bool controller = true;

        while (controller)
        {
            Console.WriteLine($"Clothes Rental System");
            int choice = 0;
            Console.WriteLine(
                $"{hr}\n" +
                "1. Sign Up\n" +
                "2. User Sign In\n" +
                "3. Admin Sign In\n" +
                "4. Exit\n");

            Console.WriteLine($"{hr}\nYour choice : ");

            bool isValid = int.TryParse(Console.ReadLine(), out choice);

            if (!isValid || choice < 1 || choice > 4)
            {
                Console.WriteLine($"{hr}\nInvalid input");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine($"{hr}\nUsername : ");
                    string? username = Console.ReadLine();

                    if (username is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    Console.WriteLine($"{hr}\nEmail : ");
                    string? email = Console.ReadLine();

                    if (email is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    Console.WriteLine($"{hr}\nPassword : ");
                    string? password = Console.ReadLine();

                    if (password is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        userController.Save(username, email, password);
                    }
                    catch (UserAlreadyExistsException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 2:
                    FeUserSignInMenu.Open();

                    break;
                case 3:
                    FeAdminSignInMenu.Open();

                    break;
                case 4:
                    controller = false;

                    break;
            }
        }
    }
}
