using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Entity.Enum;
using ClothesRentalSystem.ConsoleUI.Exception.AdminException;
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
        if (_repository.HasUsername(username)
            || _repository.HasEmail(email))
            throw new AdminAlreadyExistsException();

        Admin admin = new Admin();
        admin.Id = GenerateId.GenerateAdminId();
        admin.Auth.Username = username;
        admin.Auth.Email = email;
        admin.Auth.Password = password;
        admin.Auth.Role = ERole.ADMIN;

        _repository.Save(admin);
    }

    public Admin GetById(long id)
    {
        return _repository.GetById(id)
            ?? throw new AdminNotFoundException($"Id {id}");
    }

    public Admin GetByUsername(string username)
    {
        return _repository.GetByUsername(username)
            ?? throw new AdminNotFoundException($"Username {username}");
    }

    public Admin GetByEmail(string email)
    {
        return _repository.GetByEmail(email)
            ?? throw new AdminNotFoundException($"Email {email}");
    }
}
