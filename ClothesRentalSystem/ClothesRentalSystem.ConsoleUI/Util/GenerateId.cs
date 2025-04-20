namespace ClothesRentalSystem.ConsoleUI.Util;

public static class GenerateId
{
    private static int _userId = 0;

    public static int GenerateUserId()
    {
        _userId = _userId + 1;
        return _userId;
    }
}
