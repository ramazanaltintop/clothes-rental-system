using ClothesRentalSystem.ConsoleUI.Entity.Base;

namespace ClothesRentalSystem.ConsoleUI.Entity;

public class Clothes : BaseEntity<long>
{
    public string Name { get; set; }
    public int StockCount { get; set; }
    public long RentedCount { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }
    public DateTime CreatedAt { get; set; }

    public Clothes()
    {
        CreatedAt = DateTime.UtcNow;
    }

    public override string ToString()
    {
        return base.ToString() +
            $"Name : {Name}\n" +
            $"Stock Count : {StockCount}\n" +
            $"Rented Count : {RentedCount}\n" +
            $"Unit Price : ${Price}\n" +
            $"CreatedAt : {CreatedAt}\n" +
            $"\tCategory Id : {Category.Id}\n" +
            $"\tCategory Name : {Category.Name}\n";

    }
}
