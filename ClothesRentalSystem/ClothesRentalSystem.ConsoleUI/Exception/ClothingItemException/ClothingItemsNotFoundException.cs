using ClothesRentalSystem.ConsoleUI.Exception.Base;

namespace ClothesRentalSystem.ConsoleUI.Exception.ClothingItemException;

public class ClothingItemsNotFoundException : ClothesRentalSystemException
{
    public ClothingItemsNotFoundException()
        : base("Clothing items not found in the system.") { }
}
