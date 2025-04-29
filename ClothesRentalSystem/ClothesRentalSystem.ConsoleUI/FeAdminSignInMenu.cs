using ClothesRentalSystem.ConsoleUI.Exception.AdminException;
using ClothesRentalSystem.ConsoleUI.Exception.AuthException;
using ClothesRentalSystem.ConsoleUI.Presentation.AuthController;

namespace ClothesRentalSystem.ConsoleUI;

public static class FeAdminSignInMenu
{
    public static long PeopleId { get; set; }

    public static void Open()
    {
        string hr = Program.HR;

        Console.WriteLine($"{hr}\nAdmin Sign In");

        int choice = 0;

        while (choice != 3)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1. Sign In with Username\n" +
                "2. Sign In with Email\n" +
                "3. Return to Main Menu\n");

            Console.WriteLine($"{hr}\nYour choice : ");

            bool isValid = int.TryParse(Console.ReadLine(), out choice);

            if (!isValid || choice < 1 || choice > 3)
            {
                Console.WriteLine($"{hr}\nInvalid input");
                continue;
            }

            AdminAuthController adminAuthController = new AdminAuthController();

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

                    Console.WriteLine($"{hr}\nPassword : ");
                    string? password = Console.ReadLine();

                    if (password is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        PeopleId = adminAuthController.SignInWithUsername(username, password);
                    }
                    catch (AlreadyAuthenticatedException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }
                    catch (InvalidPasswordException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }
                    catch (AdminNotFoundException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    FeAdminMenu.Open();
                    break;
                case 2:
                    Console.WriteLine($"{hr}\nEmail : ");
                    string? email = Console.ReadLine();

                    if (email is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    Console.WriteLine($"{hr}\nPassword : ");
                    password = Console.ReadLine();

                    if (password is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        PeopleId = adminAuthController.SignInWithEmail(email, password);
                    }
                    catch (AlreadyAuthenticatedException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }
                    catch (InvalidPasswordException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }
                    catch (AdminNotFoundException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    FeAdminMenu.Open();
                    break;
                case 3:
                    break;
            }
        }
    }
}
