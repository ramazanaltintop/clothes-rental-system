using ClothesRentalSystem.Entity;
using ClothesRentalSystem.Entity.Enum;
using ClothesRentalSystem.Exception.AuthException;
using ClothesRentalSystem.Exception.ClothingItemException;
using ClothesRentalSystem.Repository;
using ClothesRentalSystem.Service.Abstract;
using ClothesRentalSystem.Util;

namespace ClothesRentalSystem.Service.Concrete;

public class ClothingItemServiceImpl : IClothingItemService
{
    private readonly ClothingItemRepository _repository;
    private readonly ICategoryService _categoryService;
    private readonly IUserService _userService;

    public ClothingItemServiceImpl(ClothingItemRepository repository,
        ICategoryService categoryService,
        IUserService userService)
    {
        _repository = repository;
        _categoryService = categoryService;
        _userService = userService;
    }

    public void Save(string name, decimal price, int stockCount, string categoryName)
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role == ERole.USER)
            throw new AdminAccessOnlyException();

        if (_repository.HasName(name))
            throw new ClothingItemAlreadyExistsException(name);

        if (stockCount < 0)
            throw new NegativeStockValueException();

        if (price < 0)
            throw new NegativePriceException();

        Category category = _categoryService.GetByName(categoryName);

        ClothingItem clothingItem = new ClothingItem();
        clothingItem.Id = GenerateId.GenerateClothingItemId();
        clothingItem.Name = name.ToLower();
        clothingItem.Price = price;
        clothingItem.StockCount = stockCount;
        clothingItem.Category = category;

        _repository.Save(clothingItem);
    }

    public List<ClothingItem> GetList()
    {
        List<ClothingItem> clothes = _repository.GetList();

        if (clothes.Count == 0)
            throw new ClothingItemsNotFoundException();

        return clothes;
    }

    public List<ClothingItem> GetListByRentable()
    {
        List<ClothingItem> clothes = _repository.GetListByRentable();

        if (clothes.Count == 0)
            throw new RentableClothingItemsNotFoundException();

        return clothes;
    }

    public List<ClothingItem> GetListByCategoryName(string categoryName)
    {
        Category category = _categoryService.GetByName(categoryName);

        List<ClothingItem> clothes = _repository.GetListByCategoryName(category.Name);

        if (clothes.Count == 0)
            throw new ClothingItemsNotFoundInCategoryException(categoryName);

        return clothes;
    }
    
    public List<ClothingItem> GetListByMostRented()
    {
        List<ClothingItem> clothes = _repository.GetListByMostRented();

        if (clothes.Count == 0)
            throw new RentedClothingItemsNotFoundException();

        return clothes;
    }

    public ClothingItem GetById(long id)
    {
        return _repository.GetById(id)
            ?? throw new ClothingItemNotFoundException($"Id {id}");
    }

    public ClothingItem GetByName(string name)
    {
        return _repository.GetByName(name)
            ?? throw new ClothingItemNotFoundException($"Name : {name}");
    }

    public void Update(string name, string newName, decimal price)
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role == ERole.USER)
            throw new AdminAccessOnlyException();

        if (price < 0)
            throw new NegativePriceException();

        ClothingItem clothingItem = GetByName(name);

        clothingItem.Name = newName.ToLower();
        clothingItem.Price = price;

        _repository.Update(clothingItem);
    }

    public void Update(string name, string categoryName)
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role == ERole.USER)
            throw new AdminAccessOnlyException();

        Category category = _categoryService.GetByName(categoryName);

        ClothingItem clothingItem = GetByName(name);

        clothingItem.Category = category;

        _repository.Update(clothingItem);
    }

    public void Update(string name, int stockCount)
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role == ERole.USER)
            throw new AdminAccessOnlyException();

        if (stockCount < 0)
            throw new NegativeStockValueException();

        ClothingItem clothingItem = GetByName(name);

        clothingItem.StockCount = stockCount;

        _repository.Update(clothingItem);
    }

    public void Remove(string name)
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role == ERole.USER)
            throw new AdminAccessOnlyException();

        ClothingItem clothingItem = GetByName(name);

        _repository.Remove(clothingItem);
    }
}
