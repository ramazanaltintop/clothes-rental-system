using ClothesRentalSystem.Entity;
using ClothesRentalSystem.Repository;
using ClothesRentalSystem.Service.Abstract;
using ClothesRentalSystem.Service.Concrete;

namespace ClothesRentalSystem.Presentation;

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
