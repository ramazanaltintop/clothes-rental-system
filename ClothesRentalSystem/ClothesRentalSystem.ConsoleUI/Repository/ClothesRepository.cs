using ClothesRentalSystem.ConsoleUI.Entity;

namespace ClothesRentalSystem.ConsoleUI.Repository;

public class ClothesRepository : List
{
    public void Save(Clothes clothes)
    {
        Clothes.Add(clothes);
    }

    public List<Clothes> GetList()
    {
        return Clothes;
    }

    public List<Clothes> GetListByRentable()
    {
        return Clothes.Where(cl => cl.StockCount > 0).ToList();
    }

    public List<Clothes> GetListByCategoryName(string categoryName)
    {
        return Clothes.Where(cl => cl.Category.Name.Equals(categoryName)).ToList();
    }

    public List<Clothes> GetListByMostRented()
    {
        return Clothes
            .Where(cl => cl.RentedCount > 0)
            .OrderByDescending(cl => cl.RentedCount)
            .Take(2)
            .ToList();
    }

    public Clothes? GetById(long id)
    {
        return Clothes.FirstOrDefault(cl => cl.Id == id);
    }

    public void Remove(Clothes clothes)
    {
        Clothes.Remove(clothes);
    }

    public bool HasName(string name)
    {
        return Clothes.Any(cl => cl.Name.Equals(name));
    }
}
