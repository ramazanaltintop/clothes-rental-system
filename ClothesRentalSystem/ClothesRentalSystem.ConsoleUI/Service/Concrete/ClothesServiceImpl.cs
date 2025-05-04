using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Entity.Enum;
using ClothesRentalSystem.ConsoleUI.Exception.AuthException;
using ClothesRentalSystem.ConsoleUI.Exception.ClothesException;
using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Util;

namespace ClothesRentalSystem.ConsoleUI.Service.Concrete;

public class ClothesServiceImpl : IClothesService
{
    private readonly ClothesRepository _repository;
    private readonly ICategoryService _categoryService;
    private readonly IAdminService _adminService;

    public ClothesServiceImpl(ClothesRepository repository,
        ICategoryService categoryService,
        IAdminService adminService)
    {
        _repository = repository;
        _categoryService = categoryService;
        _adminService = adminService;
    }

    public void Save(string name, decimal price, int stockCount, string categoryName)
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.personId);

        if (admin.Auth.Role == ERole.USER)
            throw new AdminOnlyAccessException();

        if (_repository.HasName(name))
            throw new ClothesAlreadyExistsException(name);

        if (stockCount < 0)
            throw new NegativeStockValueException();

        if (price < 0)
            throw new NegativePriceException();

        Category category = _categoryService.GetByName(categoryName);

        Clothes clothes = new Clothes();
        clothes.Id = GenerateId.GenerateClothesId();
        clothes.Name = name.ToLower();
        clothes.Price = price;
        clothes.StockCount = stockCount;
        clothes.Category = category;

        _repository.Save(clothes);
    }

    public List<Clothes> GetList()
    {
        return _repository.GetList();
    }

    public List<Clothes> GetListByRentable()
    {
        return _repository.GetListByRentable();
    }

    public List<Clothes> GetListByCategoryName(string categoryName)
    {
        Category category = _categoryService.GetByName(categoryName.ToLower());

        List<Clothes> clothes = _repository.GetListByCategoryName(category.Name.ToLower());

        if (clothes.Count == 0)
            throw new NoClothesInCategoryException(categoryName);

        return clothes;
    }
    
    public List<Clothes> GetListByMostRented()
    {
        List<Clothes> clothes = _repository.GetListByMostRented();

        if (clothes.Count == 0)
            throw new NoRentedClothesFoundException();

        return clothes;
    }

    public Clothes GetById(long id)
    {
        return _repository.GetById(id)
            ?? throw new ClothesNotFoundException($"Id {id}");
    }

    public Clothes GetByName(string name)
    {
        return _repository.GetByName(name)
            ?? throw new ClothesNotFoundException($"Name : {name}");
    }

    public void Update(string name, string newName, decimal price)
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.personId);

        if (admin.Auth.Role == ERole.USER)
            throw new AdminOnlyAccessException();

        if (price < 0)
            throw new NegativePriceException();

        Clothes clothes = GetByName(name);

        clothes.Name = newName.ToLower();
        clothes.Price = price;

        _repository.Update(clothes);
    }

    public void Update(string name, string categoryName)
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.personId);

        if (admin.Auth.Role == ERole.USER)
            throw new AdminOnlyAccessException();

        Category category = _categoryService.GetByName(categoryName);

        Clothes clothes = GetByName(name);

        clothes.Category = category;

        _repository.Update(clothes);
    }

    public void Update(string name, int stockCount)
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.personId);

        if (admin.Auth.Role == ERole.USER)
            throw new AdminOnlyAccessException();

        if (stockCount < 0)
            throw new NegativeStockValueException();

        Clothes clothes = GetByName(name);

        clothes.StockCount = stockCount;

        _repository.Update(clothes);
    }

    public void Remove(string name)
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.personId);

        if (admin.Auth.Role == ERole.USER)
            throw new AdminOnlyAccessException();

        Clothes clothes = GetByName(name);

        _repository.Remove(clothes);
    }
}
