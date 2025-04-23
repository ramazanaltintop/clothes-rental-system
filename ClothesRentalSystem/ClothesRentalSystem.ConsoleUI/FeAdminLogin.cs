using ClothesRentalSystem.ConsoleUI.Presentation.AuthController;

namespace ClothesRentalSystem.ConsoleUI;

public static class FeAdminLogin
{
    public static long PeopleId { get; set; }

    public static void OpenAdminMenu()
    {
        string hr = Program.HR;

        Console.WriteLine($"{hr}\nAdmin Login");

        int choice = 0;

        while (choice != 3)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1_Sign_In_with_Username\n" +
                "2_Sign_In_with_Email\n" +
                "3_Return_to_Main_Menu\n");

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

                    PeopleId = adminAuthController.SignInWithUsername(username, password);
                    FeAdminMenu.OpenAdminMenu();
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

                    PeopleId = adminAuthController.SignInWithEmail(email, password);
                    FeAdminMenu.OpenAdminMenu();
                    break;
                case 3:
                    break;
            }
        }
    }
}
