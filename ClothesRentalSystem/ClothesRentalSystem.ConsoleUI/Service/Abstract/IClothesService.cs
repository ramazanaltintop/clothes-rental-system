using ClothesRentalSystem.ConsoleUI.Entity;

namespace ClothesRentalSystem.ConsoleUI.Service.Abstract;

public interface IClothesService
{
    void Save(string name, decimal price, int stockCount, short categoryId, long peopleId);
    List<Clothes> GetList();
    List<Clothes> GetListByRentable();
    List<Clothes> GetListByCategoryName(string categoryName);
    List<Clothes> GetListByMostRented();
    Clothes GetById(long id);
    void Update(long id, string name, decimal price, int stockCount, long peopleId);
    void Remove(long clothesId, long peopleId);
}
