using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Entity.Enum;
using ClothesRentalSystem.ConsoleUI.Exception.AuthException;
using ClothesRentalSystem.ConsoleUI.Exception.ClothingItemException;
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
    private readonly IClothingItemService _clothingItemService;
    private readonly IAdminService _adminService;

    public RentServiceImpl(RentRepository repository, IUserService userService, IClothingItemService clothingItemService, IAdminService adminService)
    {
        _repository = repository;
        _userService = userService;
        _clothingItemService = clothingItemService;
        _adminService = adminService;
    }

    public void AddToCart(byte day, byte quantity, string clothingItemName)
    {
        User user = _userService.GetById(FeUserSignInMenu.personId);

        if (user.Auth.Role != ERole.USER)
            throw new UserAccessOnlyException();

        ClothingItem clothingItem = _clothingItemService.GetByName(clothingItemName);

        if (clothingItem.StockCount - quantity < 0)
            throw new OutOfStockException();

        if (_repository.HasCartItem(clothingItem.Name))
        {
            CartItem cartItem = _repository.GetCartItemByClothingItemName(clothingItem.Name)!;

            cartItem.Day += day;
            cartItem.Quantity += quantity;
            cartItem.TotalPrice = cartItem.Day * cartItem.Quantity * clothingItem.Price;
        }
        else
        {
            CartItem cartItem = new CartItem();
            cartItem.Day = day;
            cartItem.Quantity = quantity;
            cartItem.ClothingItem = clothingItem;
            cartItem.TotalPrice = cartItem.Day * cartItem.Quantity * clothingItem.Price;

            _repository.AddToCart(cartItem);
        }
    }

    public List<Rent> GetListByUsername(string username)
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.PersonId);

        if (admin.Auth.Role == ERole.USER)
            throw new AdminAccessOnlyException();

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
            throw new UserAccessOnlyException();

        List<Rent> rentals = _repository.GetListByApproved(user.Id);

        if (rentals.Count == 0)
            throw new ApprovedRentalRequestsNotFoundException();

        return rentals;
    }

    public List<Rent> GetListByPending()
    {
        User user = _userService.GetById(FeUserSignInMenu.personId);

        if (user.Auth.Role != ERole.USER)
            throw new UserAccessOnlyException();

        List<Rent> rentals = _repository.GetListByPending(user.Id);

        if (rentals.Count == 0)
            throw new PendingRentalRequestsNotFoundException();

        return rentals;
    }

    public List<Rent> GetListByRejected()
    {
        User user = _userService.GetById(FeUserSignInMenu.personId);

        if (user.Auth.Role != ERole.USER)
            throw new UserAccessOnlyException();

        List<Rent> rentals = _repository.GetListByRejected(user.Id);

        if (rentals.Count == 0)
            throw new RejectedRentalRequestsNotFoundException();

        return rentals;
    }

    public List<Rent> GetListByApprovedOrRejected()
    {
        User user = _userService.GetById(FeUserSignInMenu.personId);

        if (user.Auth.Role != ERole.USER)
            throw new UserAccessOnlyException();

        List<Rent> rentals = _repository.GetListByApprovedOrRejected(user.Id);

        if (rentals.Count == 0)
            throw new RentalHistoryNotFoundException();

        return rentals;
    }

    public List<Rent> GetListByPendingAll()
    {
        Admin admin = _adminService.GetById(FeUserSignInMenu.personId);

        if (admin.Auth.Role == ERole.USER)
            throw new AdminAccessOnlyException();

        List<Rent> rentals = _repository.GetListByPendingAll();

        if (rentals.Count == 0)
            throw new PendingRentalRequestsNotFoundException();

        return rentals;
    }

    public List<Rent> GetListByAdminDecision()
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.PersonId);

        if (admin.Auth.Role != ERole.SUPERADMIN)
            throw new SuperAdminAccessOnlyException();

        List<Rent> rentals = _repository.GetListByAdminDecision();

        if (rentals.Count == 0)
            throw new RentalHistoryNotFoundException();

        return rentals;
    }

    public Rent GetById(long id)
    {
        return _repository.GetById(id)
            ?? throw new RentalRequestNotFoundException();
    }

    public decimal GetTotalEarnings()
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.PersonId);

        if (admin.Auth.Role != ERole.SUPERADMIN)
            throw new AdminAccessOnlyException();

        return _repository.GetTotalEarnings();
    }

    public long GetTotalSales()
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.PersonId);

        if (admin.Auth.Role != ERole.SUPERADMIN)
            throw new AdminAccessOnlyException();

        return _repository.GetTotalSales();
    }


    
    public List<CartItem> GetCart()
    {
        User user = _userService.GetById(FeUserSignInMenu.personId);

        if (user.Auth.Role != ERole.USER)
            throw new UserAccessOnlyException();

        List<CartItem> cart = _repository.GetCart();

        if (cart.Count == 0)
            throw new EmptyCartException();

        return cart;
    }

    public void SendRequest()
    {
        User user = _userService.GetById(FeUserSignInMenu.personId);

        if (user.Auth.Role != ERole.USER)
            throw new UserAccessOnlyException();

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
        Admin admin = _adminService.GetById(FeAdminSignInMenu.PersonId);

        if (admin.Auth.Role == ERole.USER)
            throw new AdminAccessOnlyException();

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
            ClothingItem cl = _clothingItemService.GetById(item.ClothingItem.Id);
            cl.StockCount -= item.Quantity;
            cl.RentedCount += item.Quantity;
            _repository.SetTotalSales(item.Quantity);
        }

        _repository.SetTotalEarnings(rent.NetPrice);

        _repository.ApproveRequest();
    }

    public void RejectRequest(long id)
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.PersonId);

        if (admin.Auth.Role == ERole.USER)
            throw new AdminAccessOnlyException();

        Rent rent = GetById(id);

        if (rent.IsApproved == ECondition.APPROVED)
            throw new RentalRequestAlreadyApprovedException();

        if (rent.IsApproved == ECondition.REJECTED)
            throw new RentalRequestAlreadyRejectedException();

        rent.IsApproved = ECondition.REJECTED;
        rent.RentalAdmin = admin;

        _repository.RejectRequest();
    }

    public void ClearCart()
    {
        User user = _userService.GetById(FeUserSignInMenu.personId);

        if (user.Auth.Role != ERole.USER)
            throw new UserAccessOnlyException();

        _repository.ClearCart();
    }
}
