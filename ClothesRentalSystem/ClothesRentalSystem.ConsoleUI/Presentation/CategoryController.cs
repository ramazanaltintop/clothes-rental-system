using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Service.Concrete;

namespace ClothesRentalSystem.ConsoleUI.Presentation;

public class CategoryController
{
    private readonly ICategoryService _categoryService;

    public CategoryController()
    {
        _categoryService = new CategoryServiceImpl(new CategoryRepository());
    }

    // Kategori Kayit Islemi
    public void Save(string name)
    {
        _categoryService.Save(name);
    }
}
