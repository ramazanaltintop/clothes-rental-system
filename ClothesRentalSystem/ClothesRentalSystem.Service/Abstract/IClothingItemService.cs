using ClothesRentalSystem.Entity;

namespace ClothesRentalSystem.Service.Abstract;

public interface IClothingItemService
{
    void Save(string name, decimal price, int stockCount, string categoryName);

    List<ClothingItem> GetList();
    List<ClothingItem> GetListByRentable();
    List<ClothingItem> GetListByCategoryName(string categoryName);
    ClothingItem GetById(long id);
    ClothingItem GetByName(string name);

    void Update(string name, string newName, decimal price);
    void Update(string name, string categoryName);
    void Update(string name, int stockCount);

    void Remove(string name);
}
