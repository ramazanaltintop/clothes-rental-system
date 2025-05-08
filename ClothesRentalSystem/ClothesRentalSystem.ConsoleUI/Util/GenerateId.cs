namespace ClothesRentalSystem.ConsoleUI.Util;

public static class GenerateId
{
    private static long _authId = 0;
    private static long _userId = 0;
    private static short _categoryId = 0;
    private static long _clothingItemId = 0;
    private static long _rentId = 0;

    public static long GenerateAuthId()
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

    public static long GenerateClothingItemId()
    {
        _clothingItemId = _clothingItemId + 1;
        return _clothingItemId;
    }

    public static long GenerateRentId()
    {
        _rentId = _rentId + 1;
        return _rentId;
    }
}
