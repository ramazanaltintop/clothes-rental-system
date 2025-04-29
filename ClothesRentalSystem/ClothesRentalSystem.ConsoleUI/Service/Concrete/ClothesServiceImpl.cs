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

    public void Save(string name, decimal price, int stockCount, short categoryId, long peopleId)
    {
        Admin admin = _adminService.GetById(peopleId);

        if (admin.Auth.Role != ERole.ADMIN)
            throw new AdminOnlyAccessException();

        if (_repository.HasName(name))
            throw new ClothesAlreadyExistsException(name);

        Category category = _categoryService.GetById(categoryId);

        Clothes clothes = new Clothes();
        clothes.Id = GenerateId.GenerateClothesId();
        clothes.Name = name;
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
        List<Clothes> clothes = _repository.GetListByCategoryName(categoryName.ToLower());

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

    public void Update(long id, string name, decimal price, int stockCount, long peopleId)
    {
        Clothes clothes = GetById(id);

        Admin admin = _adminService.GetById(peopleId);

        if (admin.Auth.Role != ERole.ADMIN)
            throw new AdminOnlyAccessException();

        clothes.Name = name;
        clothes.Price = price;
        clothes.StockCount = stockCount;

        _repository.Update(clothes);
    }

    public void Remove(long clothesId, long peopleId)
    {
        Clothes clothes = GetById(clothesId);

        Admin admin = _adminService.GetById(peopleId);

        if (admin.Auth.Role != ERole.ADMIN)
            throw new AdminOnlyAccessException();

        _repository.Remove(clothes);
    }
}
