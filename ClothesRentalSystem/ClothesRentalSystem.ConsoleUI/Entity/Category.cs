using ClothesRentalSystem.ConsoleUI.Entity.Base;

namespace ClothesRentalSystem.ConsoleUI.Entity;

public class Category : BaseEntity<short>
{
    public string Name { get; set; }

    public Category(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return base.ToString() +
            $"Name : {Name}\n";
    }
}
