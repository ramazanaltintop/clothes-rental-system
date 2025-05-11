using ClothesRentalSystem.Exception.Base;

namespace ClothesRentalSystem.Exception.ClothingItemException;

public class ClothingItemsNotFoundException : ClothesRentalSystemException
{
    public ClothingItemsNotFoundException()
        : base("Clothing items not found in the system.") { }
}
