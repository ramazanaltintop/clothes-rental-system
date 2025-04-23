using ClothesRentalSystem.ConsoleUI.Entity;

namespace ClothesRentalSystem.ConsoleUI.Service.Abstract;

public interface ICategoryService
{
    void Save(string name);
    Category GetById(short id);
}
