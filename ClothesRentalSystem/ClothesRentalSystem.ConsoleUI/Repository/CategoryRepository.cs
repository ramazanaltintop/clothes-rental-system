using ClothesRentalSystem.ConsoleUI.Entity;

namespace ClothesRentalSystem.ConsoleUI.Repository;

public class CategoryRepository : List
{
    public void Save(Category category)
    {
        Categories.Add(category);
    }

    public Category? GetById(short id)
    {
        return Categories.FirstOrDefault(category => category.Id == id);
    }

    public bool HasName(string name)
    {
        return Categories.Any(category => category.Name.Equals(name));
    }
}
