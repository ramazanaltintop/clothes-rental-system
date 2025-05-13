using ClothesRentalSystem.Entity.Enum;
using ClothesRentalSystem.Exception.AuthException;
using ClothesRentalSystem.Exception.UserException;
using ClothesRentalSystem.Presentation;
using ClothesRentalSystem.Repository;
using ClothesRentalSystem.Util;

namespace ClothesRentalSystem.UI.ConsoleApp;

public static class FeClothesRentalSystem
{
    public static void StartProgram()
    {
        string hr = HR.Get();

        AuthController authController = new AuthController();
        UserController userController = new UserController();

        bool controller = true;

        while (controller)
        {
            Console.WriteLine($"{hr}\nClothes Rental System");
            int choice = 0;
            Console.WriteLine(
                $"{hr}\n" +
                "1. Sign Up\n" +
                "2. Sign In\n" +
                "3. Change Password\n" +
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
                        Console.WriteLine($"{username} has been registered.");
                    }
                    catch (UserAlreadyExistsException exception)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 2:
                    Console.WriteLine($"{hr}\nUsername or Email : ");
                    string? usernameOrEmail = Console.ReadLine();

                    if (usernameOrEmail is null)
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
                        List.UserId = authController.SignIn(usernameOrEmail, password);

                        Console.WriteLine($"{usernameOrEmail} successfully signed in.\n");

                        ERole role = authController.GetRole(List.UserId);
                        if (role == ERole.USER)
                        {
                            FeUserMenu.Open();
                        }
                        else
                        {
                            FeAdminMenu.Open();
                        }
                    }
                    catch (System.Exception exception) when (
                        exception is InvalidPasswordException ||
                        exception is UserNotFoundException ||
                        exception is AuthNotFoundException)
                    {
                        Console.WriteLine($"{hr}\n{exception.Message}");
                        continue;
                    }

                    break;
                case 3:
                    Console.WriteLine($"{hr}\nPlease enter your username or email.");

                    usernameOrEmail = Console.ReadLine();

                    if (usernameOrEmail is null)
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
                        userController.ChangePassword(usernameOrEmail, oldPassword, newPassword);
                        Console.WriteLine($"{usernameOrEmail} has been updated.");
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
                    controller = false;

                    break;
            }
        }
    }
}
