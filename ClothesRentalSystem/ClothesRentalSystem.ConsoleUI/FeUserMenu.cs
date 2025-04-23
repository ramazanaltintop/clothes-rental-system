using ClothesRentalSystem.ConsoleUI.Presentation.AuthController;

namespace ClothesRentalSystem.ConsoleUI;

public static class FeUserMenu
{
    public static void OpenUserMenu()
    {
        string hr = Program.HR;

        UserAuthController userAuthController = new UserAuthController();

        Console.WriteLine($"Hosgeldiniz");
        int choice = 0;
        while (choice != 4)
        {
            Console.WriteLine(
                $"{hr}\n" +
                "1_Kiyafet_Menusu\n" +
                "2_Kiralama_Menusu\n" +
                "3_Iade_Menusu\n" +
                "4_Oturumu_Kapat\n");

            Console.WriteLine($"{hr}\nSeciminiz : ");

            bool isValid = int.TryParse(Console.ReadLine(), out choice);

            if (!isValid || choice < 1 || choice > 4)
            {
                Console.WriteLine($"{hr}\nGecersiz giris");
                continue;
            }

            switch (choice)
            {
                case 1:
                    FeClothesMenu.OpenClothesMenu();
                    break;
                case 2:
                    FeRentMenu.OpenRentMenu();
                    break;
                case 3:
                    FeGiveBackMenu.OpenGiveBackMenu();
                    break;
                case 4:
                    userAuthController.SignOut(FeUserLogin.PeopleId);
                    break;
            }
        }
    }
}
