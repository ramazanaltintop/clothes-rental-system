namespace ClothesRentalSystem.ConsoleUI;

public static class FeClothesRentalSystem
{
    public static void StartProgram()
    {
        string hr = Program.HR;

        bool controller = true;

        while (controller)
        {
            Console.WriteLine($"Hosgeldiniz");
            int choice = 0;
            Console.WriteLine(
                $"{hr}\n" +
                "1_Kullanici_Girisi\n" +
                "2_Admin_Girisi\n" +
                "3_Cikis_Yap");

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
