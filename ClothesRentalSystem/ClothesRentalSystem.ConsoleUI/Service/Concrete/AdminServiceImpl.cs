using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Util;

namespace ClothesRentalSystem.ConsoleUI.Service.Concrete;

public class AdminServiceImpl : IAdminService
{
    private readonly AdminRepository _repository;

    public AdminServiceImpl(AdminRepository repository)
    {
        _repository = repository;
    }

    public void Save(string username, string email, string password)
    {
        if (_repository.CheckUsername(username))
            throw new Exception("This username already exists.");

        if (_repository.CheckEmail(email))
            throw new Exception("This email already exists.");

        Admin admin = new()
        {
            Id = (byte)GenerateId.GenerateUserId(),
            Username = username,
            Email = email,
            Password = password
        };

        _repository.Save(admin);
    }
}
