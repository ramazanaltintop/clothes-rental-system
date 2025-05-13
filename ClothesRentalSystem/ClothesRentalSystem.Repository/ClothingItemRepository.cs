using ClothesRentalSystem.Entity;

namespace ClothesRentalSystem.Repository;

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

    public bool Update(ClothingItem clothingItem)
    {
        return true;
    }

    public void Remove(ClothingItem clothingItem)
    {
        Clothes.Remove(clothingItem);
    }
}
