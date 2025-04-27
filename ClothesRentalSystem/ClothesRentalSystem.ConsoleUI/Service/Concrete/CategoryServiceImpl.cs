using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Exception.CategoryException;
using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Util;

namespace ClothesRentalSystem.ConsoleUI.Service.Concrete;

public class CategoryServiceImpl : ICategoryService
{
    private readonly CategoryRepository _repository;

    public CategoryServiceImpl(CategoryRepository repository)
    {
        _repository = repository;
    }

    public void Save(string name)
    {
        if (_repository.HasName(name.ToLower()))
            throw new CategoryAlreadyExistsException(name);

        Category category = new Category();
        category.Id = GenerateId.GenerateCategoryId();
        category.Name = name.ToLower();

        _repository.Save(category);
    }

    public Category GetById(short id)
    {
        return _repository.GetById(id)
            ?? throw new CategoryNotFoundException($"Id {id}");
    }
}
