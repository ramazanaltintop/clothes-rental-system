using ClothesRentalSystem.Entity;

namespace ClothesRentalSystem.Service.Abstract;

public interface ICategoryService
{
    void Save(string name);

    List<Category> GetList();
    Category GetByName(string name);

    void Update(string oldCategoryName, string newCategoryName);

    void Remove(string name);
}
