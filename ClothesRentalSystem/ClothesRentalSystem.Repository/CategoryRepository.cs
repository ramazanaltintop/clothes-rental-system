using ClothesRentalSystem.Entity;

namespace ClothesRentalSystem.Repository;

public class CategoryRepository : List
{
    public void Save(Category category)
    {
        Categories.Add(category);
    }

    public List<Category> GetList()
    {
        return Categories;
    }

    public Category? GetById(short id)
    {
        return Categories.FirstOrDefault(category => category.Id == id);
    }

    public Category? GetByName(string name)
    {
        return Categories.FirstOrDefault(category => category.Name.Equals(name.ToLower()));
    }

    public bool Update(Category category)
    {
        return true;
    }

    public void Remove(Category category)
    {
        Categories.Remove(category);
    }

    public bool HasName(string name)
    {
        return Categories.Any(category => category.Name.Equals(name.ToLower()));
    }
}
