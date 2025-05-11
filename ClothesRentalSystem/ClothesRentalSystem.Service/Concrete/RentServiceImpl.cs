using ClothesRentalSystem.Entity;
using ClothesRentalSystem.Entity.Enum;
using ClothesRentalSystem.Exception.AuthException;
using ClothesRentalSystem.Exception.ClothingItemException;
using ClothesRentalSystem.Exception.RentalException;
using ClothesRentalSystem.Exception.UserException;
using ClothesRentalSystem.Repository;
using ClothesRentalSystem.Service.Abstract;
using ClothesRentalSystem.Util;

namespace ClothesRentalSystem.Service.Concrete;

public class RentServiceImpl : IRentService
{
    private readonly RentRepository _repository;
    private readonly IUserService _userService;
    private readonly IClothingItemService _clothingItemService;

    public RentServiceImpl(RentRepository repository, IUserService userService, IClothingItemService clothingItemService)
    {
        _repository = repository;
        _userService = userService;
        _clothingItemService = clothingItemService;
    }

    public void AddToCart(byte day, byte quantity, string clothingItemName)
    {
        User user = _userService.GetById(List.UserId);

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
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role == ERole.USER)
            throw new AdminAccessOnlyException();

        if (!_userService.HasUsername(username))
            throw new UserNotFoundException();

        List<Rent> userRentals = _repository.GetListByUsername(username);

        if (userRentals.Count == 0)
            throw new RentalNotFoundException();

        return userRentals;
    }

    public List<Rent> GetListByApproved()
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role != ERole.USER)
            throw new UserAccessOnlyException();

        List<Rent> approvedRentals = _repository.GetListByApproved(user.Id);

        if (approvedRentals.Count == 0)
            throw new ApprovedRentalRequestsNotFoundException();

        return approvedRentals;
    }

    public List<Rent> GetListByPending()
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role != ERole.USER)
            throw new UserAccessOnlyException();

        List<Rent> pendingRentals = _repository.GetListByPending(user.Id);

        if (pendingRentals.Count == 0)
            throw new PendingRentalRequestsNotFoundException();

        return pendingRentals;
    }

    public List<Rent> GetListByRejected()
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role != ERole.USER)
            throw new UserAccessOnlyException();

        List<Rent> rejectedRentals = _repository.GetListByRejected(user.Id);

        if (rejectedRentals.Count == 0)
            throw new RejectedRentalRequestsNotFoundException();

        return rejectedRentals;
    }

    public List<Rent> GetListByApprovedOrRejected()
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role != ERole.USER)
            throw new UserAccessOnlyException();

        List<Rent> pastRentals = _repository.GetListByApprovedOrRejected(user.Id);

        if (pastRentals.Count == 0)
            throw new RentalHistoryNotFoundException();

        return pastRentals;
    }

    public List<Rent> GetListByPendingAll()
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role == ERole.USER)
            throw new AdminAccessOnlyException();

        List<Rent> pendingRentals = _repository.GetListByPending();

        if (pendingRentals.Count == 0)
            throw new PendingRentalRequestsNotFoundException();

        return pendingRentals;
    }

    public List<Rent> GetListByAdminDecision()
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role != ERole.SUPERADMIN)
            throw new SuperAdminAccessOnlyException();

        List<Rent> approvedRentals = _repository.GetListByAdminDecision();

        if (approvedRentals.Count == 0)
            throw new RentalHistoryNotFoundException();

        return approvedRentals;
    }

    public Rent GetById(long id)
    {
        return _repository.GetById(id)
            ?? throw new RentalRequestNotFoundException();
    }

    public Rent GetByFicheName(string ficheName)
    {
        return _repository.GetByFicheName(ficheName)
            ?? throw new RentalRequestNotFoundException();
    }

    public decimal GetTotalEarnings()
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role != ERole.SUPERADMIN)
            throw new AdminAccessOnlyException();

        return _repository.GetTotalEarnings();
    }

    public long GetTotalSales()
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role != ERole.SUPERADMIN)
            throw new AdminAccessOnlyException();

        return _repository.GetTotalSales();
    }
    
    public List<CartItem> GetCart()
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role != ERole.USER)
            throw new UserAccessOnlyException();

        List<CartItem> cart = _repository.GetCart();

        if (cart.Count == 0)
            throw new EmptyCartException();

        return cart;
    }

    public void SendRequest()
    {
        User user = _userService.GetById(List.UserId);

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

        rent.ApprovalStatus = ECondition.REQUESTED;

        _repository.ClearCart();
        _repository.SendRequest(rent);
    }

    public void ApproveRequest(string ficheName)
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role == ERole.USER)
            throw new AdminAccessOnlyException();

        Rent rent = GetByFicheName(ficheName);

        if (rent.ApprovalStatus == ECondition.APPROVED)
            throw new RentalRequestAlreadyApprovedException();

        if (rent.ApprovalStatus == ECondition.REJECTED)
            throw new RentalRequestAlreadyRejectedException();

        rent.ApprovalStatus = ECondition.APPROVED;
        rent.RentalApprovedBy = user;

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

    public void RejectRequest(string ficheName)
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role == ERole.USER)
            throw new AdminAccessOnlyException();

        Rent? rent = _repository.GetByFicheName(ficheName);

        if (rent is null)
            throw new RentalRequestNotFoundException();

        if (rent.ApprovalStatus == ECondition.APPROVED)
            throw new RentalRequestAlreadyApprovedException();

        if (rent.ApprovalStatus == ECondition.REJECTED)
            throw new RentalRequestAlreadyRejectedException();

        rent.ApprovalStatus = ECondition.REJECTED;
        rent.RentalApprovedBy = user;

        _repository.RejectRequest();
    }

    public void ClearCart()
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role != ERole.USER)
            throw new UserAccessOnlyException();

        _repository.ClearCart();
    }
}
