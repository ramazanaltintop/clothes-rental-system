using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Service.Concrete;

namespace ClothesRentalSystem.ConsoleUI.Presentation;

public class CategoryController
{
    private readonly ICategoryService _categoryService;

    public CategoryController()
    {
        _categoryService = new CategoryServiceImpl(new CategoryRepository(),
            new UserServiceImpl(new UserRepository()));
    }

    public void Save(string name)
    {
        _categoryService.Save(name);
    }

    public List<Category> GetList()
    {
        return _categoryService.GetList();
    }

    public void Update(string oldCategoryName, string newCategoryName)
    {
        _categoryService.Update(oldCategoryName, newCategoryName);
    }

    public void Remove(string name)
    {
        _categoryService.Remove(name);
    }
}
