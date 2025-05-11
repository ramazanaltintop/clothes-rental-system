using ClothesRentalSystem.Entity;
using ClothesRentalSystem.Entity.Enum;
using ClothesRentalSystem.Exception.AuthException;
using ClothesRentalSystem.Exception.UserException;
using ClothesRentalSystem.Repository;
using ClothesRentalSystem.Service.Abstract;
using ClothesRentalSystem.Util;

namespace ClothesRentalSystem.Service.Concrete;

public class UserServiceImpl : IUserService
{
    private readonly UserRepository _repository;

    public UserServiceImpl(UserRepository repository)
    {
        _repository = repository;
    }

    public void Save(string username, string email, string password)
    {
        if (HasUsername(username) ||
            _repository.HasEmail(email))
            throw new UserAlreadyExistsException();

        User user = new User();
        user.Id = GenerateId.GenerateUserId();
        user.Auth.Username = username;
        user.Auth.Email = email;
        user.Auth.Password = password;
        user.Auth.Role = ERole.USER;

        _repository.Save(user);
    }

    public List<User> GetListByRole(string role)
    {
        bool isValid = Enum.TryParse(role, out ERole result);

        if (!isValid) throw new RoleNotFoundException();

        User user = GetById(List.UserId);

        if (user.Auth.Role != ERole.SUPERADMIN)
            throw new SuperAdminAccessOnlyException();

        return _repository.GetListByRole(result);
    }

    public User GetById(long id)
    {
        return _repository.GetById(id)
            ?? throw new UserNotFoundException();
    }
    
    public User? GetByUsername(string username)
    {
        return _repository.GetByUsername(username);
    }

    public User? GetByEmail(string email)
    {
        return _repository.GetByEmail(email);
    }

    public void ChangePassword(string usernameOrEmail, string oldPassword, string newPassword)
    {
        User? user = GetByUsername(usernameOrEmail);

        if (user is null)
            user = GetByEmail(usernameOrEmail);

        if (user is null)
            throw new UserNotFoundException();

        if (!user.Auth.Password.Equals(oldPassword))
            throw new InvalidPasswordException();

        user.Auth.Password = newPassword;

        _repository.Update(user);
    }

    public bool HasUsername(string username)
    {
        return _repository.HasUsername(username);
    }

    public void PromoteUserToAdmin(string username)
    {
        User user = GetById(List.UserId);

        if (user.Auth.Role != ERole.SUPERADMIN)
            throw new SuperAdminAccessOnlyException();

        User? targetUser = GetByUsername(username);

        if (targetUser is null)
            throw new UserNotFoundException();

        targetUser.Auth.Role = ERole.ADMIN;
    }

    public void DemoteAdminToUser(string username)
    {
        User user = GetById(List.UserId);

        if (user.Auth.Role != ERole.SUPERADMIN)
            throw new SuperAdminAccessOnlyException();

        User? targetUser = GetByUsername(username);

        if (targetUser is null)
            throw new UserNotFoundException();

        if (targetUser.Auth.Role == ERole.SUPERADMIN)
            throw new CannotModifySuperAdminRoleException();

        targetUser.Auth.Role = ERole.USER;
    }
}
