using ClothesRentalSystem.Entity.Base;

namespace ClothesRentalSystem.Entity;

public class ClothingItem : BaseEntity
{
    public string Name { get; set; } = default!;
    public int StockCount { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; } = default!;
    public DateTime CreatedAt { get; set; }

    public ClothingItem()
    {
        CreatedAt = DateTime.UtcNow;
    }

    public override string ToString()
    {
        return base.ToString() +
            $"Name : {Name}\n" +
            $"Stock Count : {StockCount}\n" +
            $"Unit Price : ${Price}\n" +
            $"CreatedAt : {CreatedAt}\n" +
            $"\tCategory Id : {Category.Id}\n" +
            $"\tCategory Name : {Category.Name}\n";
    }
}
