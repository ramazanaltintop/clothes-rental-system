using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.ClothingItemException;

public class RentedClothingItemsNotFoundException : ClothesRentalSystemException
{
    public RentedClothingItemsNotFoundException()
        : base("Rented clothing items not found.") { }
}
