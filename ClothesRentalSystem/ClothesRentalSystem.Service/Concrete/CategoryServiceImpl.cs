using ClothesRentalSystem.Entity;
using ClothesRentalSystem.Entity.Enum;
using ClothesRentalSystem.Exception.AuthException;
using ClothesRentalSystem.Exception.CategoryException;
using ClothesRentalSystem.Repository;
using ClothesRentalSystem.Service.Abstract;
using ClothesRentalSystem.Util;

namespace ClothesRentalSystem.Service.Concrete;

public class CategoryServiceImpl : ICategoryService
{
    private readonly CategoryRepository _repository;
    private readonly IUserService _userService;

    public CategoryServiceImpl(CategoryRepository repository, IUserService userService)
    {
        _repository = repository;
        _userService = userService;
    }

    public void Save(string name)
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role == ERole.USER)
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
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role == ERole.USER)
            throw new AdminAccessOnlyException();

        Category category = GetByName(oldCategoryName);

        category.Name = newCategoryName.ToLower();

        _repository.Update(category);
    }

    public void Remove(string name)
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role == ERole.USER)
            throw new AdminAccessOnlyException();

        Category category = GetByName(name.ToLower());

        _repository.Remove(category);
    }
}
