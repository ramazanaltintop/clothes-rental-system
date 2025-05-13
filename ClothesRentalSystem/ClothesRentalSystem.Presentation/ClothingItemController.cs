using ClothesRentalSystem.Entity;
using ClothesRentalSystem.Repository;
using ClothesRentalSystem.Service.Abstract;
using ClothesRentalSystem.Service.Concrete;

namespace ClothesRentalSystem.Presentation;

public class ClothingItemController
{
    private readonly IClothingItemService _clothingItemService;

    public ClothingItemController()
    {
        _clothingItemService = new ClothingItemServiceImpl(
            new ClothingItemRepository(),
            new CategoryServiceImpl(new CategoryRepository(),
                new UserServiceImpl(new UserRepository())),
            new UserServiceImpl(new UserRepository()));
    }

    public void Save(string name, decimal price, int stockCount, string categoryName)
    {
        _clothingItemService.Save(name, price, stockCount, categoryName);
    }

    public List<ClothingItem> GetList()
    {
        return _clothingItemService.GetList();
    }

    public List<ClothingItem> GetListByRentable()
    {
        return _clothingItemService.GetListByRentable();
    }

    public List<ClothingItem> GetListByCategoryName(string categoryName)
    {
        return _clothingItemService.GetListByCategoryName(categoryName);
    }

    public void Update(string name, string newName, decimal price)
    {
        _clothingItemService.Update(name, newName, price);
    }

    public void Update(string name, string categoryName)
    {
        _clothingItemService.Update(name, categoryName);
    }

    public void Update(string name, int stockCount)
    {
        _clothingItemService.Update(name, stockCount);
    }

    public void Remove(string name)
    {
        _clothingItemService.Remove(name);
    }
}
