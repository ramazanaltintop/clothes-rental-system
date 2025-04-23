using ClothesRentalSystem.ConsoleUI.Presentation.AuthController;

namespace ClothesRentalSystem.ConsoleUI;

public static class FeUserLogin
{
    public static long PeopleId { get; set; }

    public static void OpenUserMenu()
    {
        string hr = Program.HR;

        UserAuthController userAuthController = new UserAuthController();

        Console.WriteLine($"{hr}\nKullanici Girisi");

        int choice = 0;

        while (choice != 3)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1_Username_ile_Giris\n" +
                "2_Email_ile_Giris\n" +
                "3_Ust_Menuye_Don\n");

            Console.WriteLine($"{hr}\nSeciminiz : ");

            bool isValid = int.TryParse(Console.ReadLine(), out choice);

            if (!isValid || choice < 1 || choice > 3)
            {
                Console.WriteLine($"{hr}\nGecersiz giris");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine($"{hr}\nUsername : ");
                    string? username = Console.ReadLine();

                    if (username is null)
                    {
                        Console.WriteLine($"{hr}\nGecersiz giris");
                        continue;
                    }

                    Console.WriteLine($"{hr}\nPassword : ");

                    string? password = Console.ReadLine();

                    if (password is null)
                    {
                        Console.WriteLine($"{hr}\nGecersiz giris");
                        continue;
                    }

                    PeopleId = userAuthController.SignInWithUsername(username, password);
                    FeUserMenu.OpenUserMenu();
                    break;
                case 2:
                    Console.WriteLine($"{hr}\nEmail : ");
                    string? email = Console.ReadLine();

                    if (email is null)
                    {
                        Console.WriteLine($"{hr}\nGecersiz giris");
                        continue;
                    }

                    Console.WriteLine($"{hr}\nPassword : ");
                    password = Console.ReadLine();

                    if (password is null)
                    {
                        Console.WriteLine($"{hr}\nGecersiz giris");
                        continue;
                    }

                    PeopleId = userAuthController.SignInWithEmail(email, password);
                    FeUserMenu.OpenUserMenu();
                    break;
                case 3:
                    break;
            }
        }
    }
}
