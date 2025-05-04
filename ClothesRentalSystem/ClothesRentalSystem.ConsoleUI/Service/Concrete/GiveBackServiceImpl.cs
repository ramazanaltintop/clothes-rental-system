using ClothesRentalSystem.ConsoleUI.Entity.Enum;
using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Service.Abstract;
using ClothesRentalSystem.ConsoleUI.Exception.AuthException;
using ClothesRentalSystem.ConsoleUI.Exception.GiveBackException;
using ClothesRentalSystem.ConsoleUI.Repository;
using ClothesRentalSystem.ConsoleUI.Exception.RentalException;

namespace ClothesRentalSystem.ConsoleUI.Service.Concrete;

public class GiveBackServiceImpl : IGiveBackService
{
    private readonly GiveBackRepository _repository;
    private readonly IUserService _userService;
    private readonly IAdminService _adminService;
    private readonly IClothesService _clothesService;
    private readonly IRentService _rentService;

    public GiveBackServiceImpl(GiveBackRepository repository, IUserService userService, IAdminService adminService, IClothesService clothesService, IRentService rentService)
    {
        _repository = repository;
        _userService = userService;
        _adminService = adminService;
        _clothesService = clothesService;
        _rentService = rentService;
    }

    public List<Rent> GetListByUsername(string username)
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.personId);

        if (admin.Auth.Role == ERole.USER)
            throw new AdminOnlyAccessException();

        _userService.HasUsername(username);

        List<Rent> giveBacks = _repository.GetListByUsername(username);

        if (giveBacks.Count == 0)
            throw new GiveBackNotFoundException();

        return giveBacks;
    }

    public List<Rent> GetListByApproved()
    {
        User user = _userService.GetById(FeUserSignInMenu.personId);

        if (user.Auth.Role != ERole.USER)
            throw new UserOnlyAccessException();

        List<Rent> approvedRentals = _repository.GetListByApproved(user.Id);

        if (approvedRentals.Count == 0)
            throw new NoApprovedGiveBackRequestsException();

        return approvedRentals;
    }

    public List<Rent> GetListByPending()
    {
        User user = _userService.GetById(FeUserSignInMenu.personId);

        if (user.Auth.Role != ERole.USER)
            throw new UserOnlyAccessException();

        List<Rent> pendingRentals = _repository.GetListByPending(user.Id);

        if (pendingRentals.Count == 0)
            throw new NoPendingGiveBackRequestsException();

        return pendingRentals;
    }

    public List<Rent> GetListByRejected()
    {
        User user = _userService.GetById(FeUserSignInMenu.personId);

        if (user.Auth.Role != ERole.USER)
            throw new UserOnlyAccessException();

        List<Rent> rejectedRentals = _repository.GetListByRejected(user.Id);

        if (rejectedRentals.Count == 0)
            throw new NoRejectedGiveBackRequestsException();

        return rejectedRentals;
    }

    public List<Rent> GetListByApprovedOrRejected()
    {
        User user = _userService.GetById(FeUserSignInMenu.personId);

        if (user.Auth.Role != ERole.USER)
            throw new UserOnlyAccessException();

        List<Rent> pastRentals = _repository.GetListByApprovedOrRejected(user.Id);

        if (pastRentals.Count == 0)
            throw new NoGiveBackHistoryFoundException();

        return pastRentals;
    }

    public List<Rent> GetListByPendingAll()
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.personId);

        if (admin.Auth.Role == ERole.USER)
            throw new AdminOnlyAccessException();

        List<Rent> giveBacks = _repository.GetListByPendingAll();

        if (giveBacks.Count == 0)
            throw new NoPendingGiveBackRequestsException();

        return giveBacks;
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

    public void SendRequest(long rentId)
    {
        User user = _userService.GetById(FeUserSignInMenu.personId);

        if (user.Auth.Role != ERole.USER)
            throw new UserOnlyAccessException();

        Rent rent = _rentService.GetById(rentId);

        if (rent.IsApproved != ECondition.APPROVED)
            throw new GiveBackRequestNotAllowedException();

        if (rent.GiveBack == ECondition.REQUESTED)
            throw new GiveBackRequestAlreadySentException();

        rent.GiveBack = ECondition.REQUESTED;

        _repository.SendRequest(rent);
    }

    public void ApproveRequest(long rentId)
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.personId);

        if (admin.Auth.Role == ERole.USER)
            throw new AdminOnlyAccessException();

        Rent rent = _rentService.GetById(rentId);

        if (rent.GiveBack != ECondition.REQUESTED)
            throw new GiveBackRequestNotFoundException();

        if (rent.GiveBack == ECondition.APPROVED)
            throw new GiveBackRequestAlreadyApprovedException();

        rent.GiveBack = ECondition.APPROVED;
        rent.GiveBackAdmin = admin;

        List<CartItem> items = rent.CartItems;

        foreach (CartItem item in items)
        {
            Clothes cl = _clothesService.GetById(item.Clothes.Id);
            cl.StockCount += item.Quantity;
        }

        _repository.ApproveRequest();
    }

    public void RejectRequest(long rentId)
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.personId);

        if (admin.Auth.Role == ERole.USER)
            throw new AdminOnlyAccessException();

        Rent rent = _rentService.GetById(rentId);

        if (rent.GiveBack != ECondition.REQUESTED)
            throw new GiveBackRequestNotFoundException();

        if (rent.GiveBack == ECondition.REJECTED)
            throw new GiveBackRequestAlreadyRejectedException();

        rent.GiveBack = ECondition.REJECTED;
        rent.GiveBackAdmin = admin;

        _repository.RejectRequest();
    }
}
