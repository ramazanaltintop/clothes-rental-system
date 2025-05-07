using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.ClothingItemException;

public class RentableClothingItemsNotFoundException : ClothesRentalSystemException
{
    public RentableClothingItemsNotFoundException()
        : base("Rentable clothing items not found in the system.") { }
}
