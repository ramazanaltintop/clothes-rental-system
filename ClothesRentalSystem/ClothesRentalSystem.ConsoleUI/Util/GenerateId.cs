namespace ClothesRentalSystem.ConsoleUI.Util;

public static class GenerateId
{
    private static short _adminId = 0;
    private static int _authId = 0;
    private static long _userId = 0;
    private static short _categoryId = 0;
    private static long _clothesId = 0;
    private static long _rentId = 0;

    public static short GenerateAdminId()
    {
        _adminId = (short)(_adminId + 1);
        return _adminId;
    }

    public static int GenerateAuthId()
    {
        _authId = _authId + 1;
        return _authId;
    }

    public static long GenerateUserId()
    {
        _userId = _userId + 1;
        return _userId;
    }

    public static short GenerateCategoryId()
    {
        _categoryId = (short)(_categoryId + 1);
        return _categoryId;
    }

    public static long GenerateClothesId()
    {
        _clothesId = _clothesId + 1;
        return _clothesId;
    }

    public static long GenerateRentId()
    {
        _rentId = _rentId + 1;
        return _rentId;
    }
}
