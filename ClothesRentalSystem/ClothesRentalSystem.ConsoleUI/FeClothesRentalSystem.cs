namespace ClothesRentalSystem.ConsoleUI;

public static class FeClothesRentalSystem
{
    public static void StartProgram()
    {
        string hr = Program.HR;

        bool controller = true;

        while (controller)
        {
            Console.WriteLine($"Welcome");
            int choice = 0;
            Console.WriteLine(
                $"{hr}\n" +
                "1_User_Login\n" +
                "2_Admin_Login\n" +
                "3_Exit");

            Console.WriteLine($"{hr}\nYour choice : ");

            bool isValid = int.TryParse(Console.ReadLine(), out choice);

            if (!isValid || choice < 1 || choice > 3)
            {
                Console.WriteLine($"{hr}\nInvalid input");
                continue;
            }

            switch (choice)
            {
                case 1:
                    FeUserLogin.OpenUserMenu();
                    break;
                case 2:
                    FeAdminLogin.OpenAdminMenu();
                    break;
                case 3:
                    controller = false;
                    break;
            }
        }
    }
}
