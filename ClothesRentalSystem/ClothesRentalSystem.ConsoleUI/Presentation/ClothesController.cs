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
            new CategoryServiceImpl(new CategoryRepository(),
                new AdminServiceImpl(new AdminRepository(),
                    new UserServiceImpl(new UserRepository()))),
            new AdminServiceImpl(new AdminRepository()
            , new UserServiceImpl(new UserRepository())));
    }

    public void Save(string name, decimal price, int stockCount, string categoryName)
    {
        _clothesService.Save(name, price, stockCount, categoryName);
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

    public void Update(string name, string newName, decimal price)
    {
        _clothesService.Update(name, newName, price);
    }

    public void Update(string name, string categoryName)
    {
        _clothesService.Update(name, categoryName);
    }

    public void Update(string name, int stockCount)
    {
        _clothesService.Update(name, stockCount);
    }

    public void Remove(string name)
    {
        _clothesService.Remove(name);
    }
}
