using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Entity.Enum;
using ClothesRentalSystem.ConsoleUI.Exception.AuthException;
using ClothesRentalSystem.ConsoleUI.Exception.CategoryException;
using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Util;

namespace ClothesRentalSystem.ConsoleUI.Service.Concrete;

public class CategoryServiceImpl : ICategoryService
{
    private readonly CategoryRepository _repository;
    private readonly IAdminService _adminService;

    public CategoryServiceImpl(CategoryRepository repository, IAdminService adminService)
    {
        _repository = repository;
        _adminService = adminService;
    }

    public void Save(string name)
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.PersonId);

        if (admin.Auth.Role == ERole.USER)
            throw new AdminAccessOnlyException();

        if (_repository.HasName(name))
            throw new CategoryAlreadyExistsException(name);

        Category category = new Category(name.ToLower());
        category.Id = GenerateId.GenerateCategoryId();

        _repository.Save(category);
    }

    public List<Category> GetList()
    {
        List<Category> categories = _repository.GetList();

        if (categories.Count == 0)
            throw new CategoriesNotFoundException();

        return categories;
    }

    public Category GetByName(string name)
    {
        return _repository.GetByName(name)
            ?? throw new CategoryNotFoundException($"Name {name}");
    }

    public void Update(string oldCategoryName, string newCategoryName)
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.PersonId);

        if (admin.Auth.Role == ERole.USER)
            throw new AdminAccessOnlyException();

        Category category = GetByName(oldCategoryName);

        category.Name = newCategoryName.ToLower();

        _repository.Update(category);
    }

    public void Remove(string name)
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.PersonId);

        if (admin.Auth.Role == ERole.USER)
            throw new AdminAccessOnlyException();

        Category category = GetByName(name.ToLower());

        _repository.Remove(category);
    }
}
