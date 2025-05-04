using ClothesRentalSystem.ConsoleUI.Entity;

namespace ClothesRentalSystem.ConsoleUI.Service.Abstract;

public interface IClothesService
{
    void Save(string name, decimal price, int stockCount, string categoryName);

    List<Clothes> GetList();
    List<Clothes> GetListByRentable();
    List<Clothes> GetListByCategoryName(string categoryName);
    List<Clothes> GetListByMostRented();
    Clothes GetById(long id);
    Clothes GetByName(string name);

    void Update(string name, string newName, decimal price);
    void Update(string name, string categoryName);
    void Update(string name, int stockCount);

    void Remove(string name);
}
