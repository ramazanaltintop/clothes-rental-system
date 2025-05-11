using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.ClothingItemException;

public class RentableClothingItemsNotFoundException : ClothesRentalSystemException
{
    public RentableClothingItemsNotFoundException()
        : base("Rentable clothing items not found in the system.") { }
}
