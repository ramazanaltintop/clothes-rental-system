using ClothesRentalSystem.ConsoleUI.Entity.Base;

namespace ClothesRentalSystem.ConsoleUI.Entity;

public class Category : BaseEntity<short>
{
    public string Name { get; set; }

    public override string ToString()
    {
        return base.ToString() +
            $"Name : {Name}\n";
    }
}
