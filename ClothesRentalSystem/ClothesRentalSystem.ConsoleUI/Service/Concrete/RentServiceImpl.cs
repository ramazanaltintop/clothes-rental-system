using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Entity.Enum;
using ClothesRentalSystem.ConsoleUI.Exception.AuthException;
using ClothesRentalSystem.ConsoleUI.Exception.ClothesException;
using ClothesRentalSystem.ConsoleUI.Exception.RentalException;
using ClothesRentalSystem.ConsoleUI.Exception.UserException;
using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Util;

namespace ClothesRentalSystem.ConsoleUI.Service.Concrete;

public class RentServiceImpl : IRentService
{
    private readonly RentRepository _repository;
    private readonly IUserService _userService;
    private readonly IClothesService _clothesService;
    private readonly IAdminService _adminService;

    public RentServiceImpl(RentRepository repository, IUserService userService, IClothesService clothesService, IAdminService adminService)
    {
        _repository = repository;
        _userService = userService;
        _clothesService = clothesService;
        _adminService = adminService;
    }

    public void AddToCart(byte day, byte quantity, string clothesName)
    {
        User user = _userService.GetById(FeUserSignInMenu.personId);

        if (user.Auth.Role != ERole.USER)
            throw new UserOnlyAccessException();

        Clothes clothes = _clothesService.GetByName(clothesName);

        if (clothes.StockCount - quantity < 0)
            throw new OutOfStockException();

        if (_repository.HasCartItem(clothes.Name))
        {
            CartItem cartItem = _repository.GetCartItemByClothesName(clothes.Name)!;

            cartItem.Day += day;
            cartItem.Quantity += quantity;
            cartItem.TotalPrice = cartItem.Day * cartItem.Quantity * clothes.Price;
        }
        else
        {
            CartItem cartItem = new CartItem();
            cartItem.Day = day;
            cartItem.Quantity = quantity;
            cartItem.Clothes = clothes;
            cartItem.TotalPrice = cartItem.Day * cartItem.Quantity * clothes.Price;

            _repository.AddToCart(cartItem);
        }
    }

    public List<Rent> GetListByUsername(string username)
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.personId);

        if (admin.Auth.Role == ERole.USER)
            throw new AdminOnlyAccessException();

        if (!_userService.HasUsername(username))
            throw new UserNotFoundException($"Username : {username}");

        List<Rent> rentals = _repository.GetListByUsername(username);

        if (rentals.Count == 0)
            throw new RentalNotFoundException();

        return rentals;
    }

    public List<Rent> GetListByApproved()
    {
        User user = _userService.GetById(FeUserSignInMenu.personId);

        if (user.Auth.Role != ERole.USER)
            throw new UserOnlyAccessException();

        List<Rent> approvedRentals = _repository.GetListByApproved(user.Id);

        if (approvedRentals.Count == 0)
            throw new NoApprovedRentalRequestsException();

        return approvedRentals;
    }

    public List<Rent> GetListByPending()
    {
        User user = _userService.GetById(FeUserSignInMenu.personId);

        if (user.Auth.Role != ERole.USER)
            throw new UserOnlyAccessException();

        List<Rent> pendingRentals = _repository.GetListByPending(user.Id);

        if (pendingRentals.Count == 0)
            throw new NoPendingRentalRequestsException();

        return pendingRentals;
    }

    public List<Rent> GetListByRejected()
    {
        User user = _userService.GetById(FeUserSignInMenu.personId);

        if (user.Auth.Role != ERole.USER)
            throw new UserOnlyAccessException();

        List<Rent> rejectedRentals = _repository.GetListByRejected(user.Id);

        if (rejectedRentals.Count == 0)
            throw new NoRejectedRentalRequestsException();

        return rejectedRentals;
    }

    public List<Rent> GetListByApprovedOrRejected()
    {
        User user = _userService.GetById(FeUserSignInMenu.personId);

        if (user.Auth.Role != ERole.USER)
            throw new UserOnlyAccessException();

        List<Rent> pastRentals = _repository.GetListByApprovedOrRejected(user.Id);

        if (pastRentals.Count == 0)
            throw new NoRentalHistoryFoundException();

        return pastRentals;
    }

    public List<Rent> GetListByPendingAll()
    {
        Admin admin = _adminService.GetById(FeUserSignInMenu.personId);

        if (admin.Auth.Role == ERole.USER)
            throw new AdminOnlyAccessException();

        List<Rent> rentals = _repository.GetListByPendingAll();

        if (rentals.Count == 0)
            throw new NoPendingRentalRequestsException();

        return rentals;
    }

    public List<Rent> GetListByAdminDecision()
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.personId);

        if (admin.Auth.Role != ERole.SUPERADMIN)
            throw new RequireSuperAdminRoleException();

        List<Rent> rentals = _repository.GetListByAdminDecision();

        if (rentals.Count == 0)
            throw new NoRentalHistoryFoundException();

        return rentals;
    }

    public Rent GetById(long id)
    {
        return _repository.GetById(id)
            ?? throw new RentalRequestNotFoundException();
    }

    public decimal GetTotalEarnings()
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.personId);

        if (admin.Auth.Role != ERole.SUPERADMIN)
            throw new AdminOnlyAccessException();

        return _repository.GetTotalEarnings();
    }

    public long GetTotalSales()
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.personId);

        if (admin.Auth.Role != ERole.SUPERADMIN)
            throw new AdminOnlyAccessException();

        return _repository.GetTotalSales();
    }


    
    public List<CartItem> GetCart()
    {
        User user = _userService.GetById(FeUserSignInMenu.personId);

        if (user.Auth.Role != ERole.USER)
            throw new UserOnlyAccessException();

        List<CartItem> cart = _repository.GetCart();

        if (cart.Count == 0)
            throw new EmptyCartException();

        return cart;
    }

    public void SendRequest()
    {
        User user = _userService.GetById(FeUserSignInMenu.personId);

        if (user.Auth.Role != ERole.USER)
            throw new UserOnlyAccessException();

        List<CartItem> cartItems = _repository.GetCart();

        if (cartItems.Count == 0)
            throw new EmptyCartException();

        Rent rent = new Rent();
        rent.Id = GenerateId.GenerateRentId();
        rent.User = user;

        foreach (CartItem cartItem in cartItems)
        {
            rent.CartItems.Add(cartItem);
            rent.NetPrice += cartItem.TotalPrice;
            cartItem.Rent = rent;
        }

        rent.IsApproved = ECondition.REQUESTED;

        _repository.ClearCart();
        _repository.SendRequest(rent);
    }

    public void ApproveRequest(long id)
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.personId);

        if (admin.Auth.Role == ERole.USER)
            throw new AdminOnlyAccessException();

        Rent rent = GetById(id);

        if (rent.IsApproved == ECondition.APPROVED)
            throw new RentalRequestAlreadyApprovedException();

        if (rent.IsApproved == ECondition.REJECTED)
            throw new RentalRequestAlreadyRejectedException();

        rent.IsApproved = ECondition.APPROVED;
        rent.RentalAdmin = admin;

        List<CartItem> items = rent.CartItems;

        foreach (CartItem item in items)
        {
            Clothes cl = _clothesService.GetById(item.Clothes.Id);
            cl.StockCount -= item.Quantity;
            cl.RentedCount += item.Quantity;
            _repository.SetTotalSales(item.Quantity);
        }

        _repository.SetTotalEarnings(rent.NetPrice);

        _repository.ApproveRequest();
    }

    public void RejectRequest(long id)
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.personId);

        if (admin.Auth.Role == ERole.USER)
            throw new AdminOnlyAccessException();

        Rent rent = GetById(id);

        if (rent.IsApproved == ECondition.APPROVED)
            throw new RentalRequestAlreadyApprovedException();

        if (rent.IsApproved == ECondition.REJECTED)
            throw new RentalRequestAlreadyRejectedException();

        rent.IsApproved = ECondition.REJECTED;
        rent.RentalAdmin = admin;

        _repository.RejectRequest();
    }
}
