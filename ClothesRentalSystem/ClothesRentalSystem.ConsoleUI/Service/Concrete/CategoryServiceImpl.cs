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
        Admin admin = _adminService.GetById(FeAdminSignInMenu.personId);

        if (admin.Auth.Role == ERole.USER)
            throw new AdminOnlyAccessException();

        if (_repository.HasName(name.ToLower()))
            throw new CategoryAlreadyExistsException(name);

        Category category = new Category();
        category.Id = GenerateId.GenerateCategoryId();
        category.Name = name.ToLower();

        _repository.Save(category);
    }

    public List<Category> GetList()
    {
        return _repository.GetList();
    }

    public Category GetById(short id)
    {
        return _repository.GetById(id)
            ?? throw new CategoryNotFoundException($"Id {id}");
    }

    public Category GetByName(string name)
    {
        return _repository.GetByName(name)
            ?? throw new CategoryNotFoundException($"Name {name}");
    }

    public void Update(string oldCategoryName, string newCategoryName)
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.personId);

        if (admin.Auth.Role == ERole.USER)
            throw new AdminOnlyAccessException();

        Category category = GetByName(oldCategoryName);

        category.Name = newCategoryName.ToLower();

        _repository.Update(category);
    }

    public void Remove(string name)
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.personId);

        if (admin.Auth.Role == ERole.USER)
            throw new AdminOnlyAccessException();

        Category category = GetByName(name.ToLower());

        _repository.Remove(category);
    }
}
