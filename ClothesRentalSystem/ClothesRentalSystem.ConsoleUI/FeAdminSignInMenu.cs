using ClothesRentalSystem.ConsoleUI.Exception.AdminException;
using ClothesRentalSystem.ConsoleUI.Exception.AuthException;
using ClothesRentalSystem.ConsoleUI.Exception.UserException;
using ClothesRentalSystem.ConsoleUI.Presentation;

namespace ClothesRentalSystem.ConsoleUI;

public static class FeAdminSignInMenu
{
    public static long PersonId { get; set; }

    public static void Open()
    {
        string hr = Program.HR;

        Console.WriteLine($"{hr}\nAdmin Sign In");

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1. Sign In with Username\n" +
                "2. Sign In with Email\n" +
                "3. Change Password with Username\n" +
                "4. Change Password with Email\n" +
                "5. Return to Main Menu\n");

            Console.WriteLine($"{hr}\nYour choice : ");

            bool isValid = int.TryParse(Console.ReadLine(), out choice);

            if (!isValid || choice < 1 || choice > 5)
            {
                Console.WriteLine($"{hr}\nInvalid input");
                continue;
            }

            AdminAuthController adminAuthController = new AdminAuthController();
            AdminController adminController = new AdminController();

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
                        PersonId = adminAuthController.SignInWithUsername(username, password);
                    }
                    catch (System.Exception exception) when (
                        exception is AlreadyAuthenticatedException ||
                        exception is InvalidPasswordException ||
                        exception is AdminNotFoundException)
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
                        PersonId = adminAuthController.SignInWithEmail(email, password);
                    }
                    catch (System.Exception exception) when (
                        exception is AlreadyAuthenticatedException ||
                        exception is InvalidPasswordException ||
                        exception is AdminNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    FeAdminMenu.Open();

                    break;
                case 3:
                    Console.WriteLine($"{hr}\nPlease enter your username.");

                    username = Console.ReadLine();

                    if (username is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    Console.WriteLine($"{hr}\nPlease enter your old password.");

                    string? oldPassword = Console.ReadLine();

                    if (oldPassword is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    Console.WriteLine($"{hr}\nPlease enter your new password.");

                    string? newPassword = Console.ReadLine();

                    if (newPassword is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        adminController.ChangePasswordWithUsername(username, oldPassword, newPassword);
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is InvalidPasswordException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 4:
                    Console.WriteLine($"{hr}\nPlease enter your email.");

                    email = Console.ReadLine();

                    if (email is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    Console.WriteLine($"{hr}\nPlease enter your old password.");

                    oldPassword = Console.ReadLine();

                    if (oldPassword is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    Console.WriteLine($"{hr}\nPlease enter your new password.");

                    newPassword = Console.ReadLine();

                    if (newPassword is null)
                    {
                        Console.WriteLine($"{hr}\nInvalid input");
                        continue;
                    }

                    try
                    {
                        adminController.ChangePasswordWithEmail(email, oldPassword, newPassword);
                    }
                    catch (System.Exception exception) when (
                        exception is UserNotFoundException ||
                        exception is InvalidPasswordException)
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
