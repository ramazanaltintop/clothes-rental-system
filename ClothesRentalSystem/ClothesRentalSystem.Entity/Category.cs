using ClothesRentalSystem.Entity.Base;

namespace ClothesRentalSystem.Entity;

public class Category : BaseEntity
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
