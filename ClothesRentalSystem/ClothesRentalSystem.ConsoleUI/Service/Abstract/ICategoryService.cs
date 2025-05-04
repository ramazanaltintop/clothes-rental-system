using ClothesRentalSystem.ConsoleUI.Entity;

namespace ClothesRentalSystem.ConsoleUI.Service.Abstract;

public interface ICategoryService
{
    void Save(string name);

    List<Category> GetList();
    Category GetById(short id);
    Category GetByName(string name);

    void Update(string oldCategoryName, string newCategoryName);

    void Remove(string name);
}
