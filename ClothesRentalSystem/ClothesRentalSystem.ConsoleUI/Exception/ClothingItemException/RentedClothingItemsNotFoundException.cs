using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.ClothingItemException;

public class RentedClothingItemsNotFoundException : ClothesRentalSystemException
{
    public RentedClothingItemsNotFoundException()
        : base("Rented clothing items not found.") { }
}
