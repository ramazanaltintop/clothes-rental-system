using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Service.Concrete;

namespace ClothesRentalSystem.ConsoleUI.Presentation;

public class ClothesController
{
    private readonly IClothesService _clothesService;

    public ClothesController()
    {
        _clothesService = new ClothesServiceImpl(
            new ClothesRepository(),
            new CategoryServiceImpl(new CategoryRepository()),
            new AdminServiceImpl(new AdminRepository()
            , new UserServiceImpl(new UserRepository())));
    }

    public void Save(string name, decimal price, int stockCount, short categoryId, long peopleId)
    {
        _clothesService.Save(name, price, stockCount, categoryId, peopleId);
    }

    public List<Clothes> GetList()
    {
        return _clothesService.GetList();
    }

    public List<Clothes> GetListByRentable()
    {
        return _clothesService.GetListByRentable();
    }

    public List<Clothes> GetListByCategoryName(string categoryName)
    {
        return _clothesService.GetListByCategoryName(categoryName);
    }

    public List<Clothes> GetListByMostRented()
    {
        return _clothesService.GetListByMostRented();
    }

    public Clothes GetById(long id)
    {
        return _clothesService.GetById(id);
    }

    public void Update(long id, string name, decimal price, int stockCount, long peopleId)
    {
        _clothesService.Update(id, name, price, stockCount, peopleId);
    }

    public void Remove(long clothesId, long peopleId)
    {
        _clothesService.Remove(clothesId, peopleId);
    }
}
