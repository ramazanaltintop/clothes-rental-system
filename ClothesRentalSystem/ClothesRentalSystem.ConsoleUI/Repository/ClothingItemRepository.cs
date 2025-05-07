using ClothesRentalSystem.ConsoleUI.Entity;

namespace ClothesRentalSystem.ConsoleUI.Repository;

public class ClothingItemRepository : List
{
    public void Save(ClothingItem clothingItem)
    {
        Clothes.Add(clothingItem);
    }

    public List<ClothingItem> GetList()
    {
        return Clothes;
    }

    public List<ClothingItem> GetListByRentable()
    {
        return Clothes.Where(cl => cl.StockCount > 0).ToList();
    }

    public List<ClothingItem> GetListByCategoryName(string categoryName)
    {
        return Clothes.Where(cl => cl.Category.Name.Equals(categoryName)).ToList();
    }

    public List<ClothingItem> GetListByMostRented()
    {
        return Clothes
            .Where(cl => cl.RentedCount > 0)
            .OrderByDescending(cl => cl.RentedCount)
            .Take(5)
            .ToList();
    }

    public ClothingItem? GetById(long id)
    {
        return Clothes.FirstOrDefault(cl => cl.Id == id);
    }

    public ClothingItem? GetByName(string name)
    {
        return Clothes.FirstOrDefault(cl => cl.Name.Equals(name.ToLower()));
    }

    public bool HasName(string name)
    {
        return Clothes.Any(cl => cl.Name.Equals(name.ToLower()));
    }

    public void Update(ClothingItem clothingItem)
    {
        Console.WriteLine($"{clothingItem.Name} has been successfully updated.");
    }

    public void Remove(ClothingItem clothingItem)
    {
        Clothes.Remove(clothingItem);
    }
}
