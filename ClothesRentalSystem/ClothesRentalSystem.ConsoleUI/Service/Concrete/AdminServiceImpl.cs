using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Entity.Enum;
using ClothesRentalSystem.ConsoleUI.Exception.AdminException;
using ClothesRentalSystem.ConsoleUI.Exception.AuthException;
using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Util;

namespace ClothesRentalSystem.ConsoleUI.Service.Concrete;

public class AdminServiceImpl : IAdminService
{
    private readonly AdminRepository _repository;
    private readonly IUserService _userService;

    public AdminServiceImpl(AdminRepository repository, IUserService userService)
    {
        _repository = repository;
        _userService = userService;
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

    public List<Admin> GetList()
    {
        Admin admin = GetById(FeAdminSignInMenu.personId);

        if (admin.Auth.Role != ERole.SUPERADMIN)
            throw new AdminOnlyAccessException();

        return _repository.GetList();
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

    public void SaveSuperAdmin(string username, string email, string password)
    {
        if (_repository.HasUsername(username)
            || _repository.HasEmail(email))
            throw new AdminAlreadyExistsException();

        Admin admin = new Admin();
        admin.Id = GenerateId.GenerateAdminId();
        admin.Auth.Username = username;
        admin.Auth.Email = email;
        admin.Auth.Password = password;
        admin.Auth.Role = ERole.SUPERADMIN;

        _repository.Save(admin);
    }

    public void PromoteUserToAdmin(string username)
    {
        Admin admin = GetById(FeAdminSignInMenu.personId);

        if (admin.Auth.Role != ERole.SUPERADMIN)
            throw new AdminOnlyAccessException();

        User user = _userService.GetByUsername(username);

        Save(user.Auth.Username, user.Auth.Email, user.Auth.Password);

        _userService.Remove(user.Id);
    }

    public void DemoteAdminToUser(string username)
    {
        Admin admin = GetById(FeAdminSignInMenu.personId);

        if (admin.Auth.Role != ERole.SUPERADMIN)
            throw new AdminOnlyAccessException();

        admin = GetByUsername(username);

        if (admin.Auth.Role == ERole.SUPERADMIN)
            throw new CannotModifySuperAdminRoleException();

        _userService.Save(admin.Auth.Username, admin.Auth.Email, admin.Auth.Password);

        _repository.Remove(admin);
    }
}
