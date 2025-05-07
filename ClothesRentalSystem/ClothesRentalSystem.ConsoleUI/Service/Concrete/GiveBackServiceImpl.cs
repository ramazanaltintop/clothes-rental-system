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
    private readonly IClothingItemService _clothingItemService;
    private readonly IRentService _rentService;

    public GiveBackServiceImpl(GiveBackRepository repository, IUserService userService, IAdminService adminService, IClothingItemService clothingItemService, IRentService rentService)
    {
        _repository = repository;
        _userService = userService;
        _adminService = adminService;
        _clothingItemService = clothingItemService;
        _rentService = rentService;
    }

    public List<Rent> GetListByUsername(string username)
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.PersonId);

        if (admin.Auth.Role == ERole.USER)
            throw new AdminAccessOnlyException();

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
            throw new UserAccessOnlyException();

        List<Rent> giveBacks = _repository.GetListByApproved(user.Id);

        if (giveBacks.Count == 0)
            throw new ApprovedGiveBackRequestsNotFoundException();

        return giveBacks;
    }

    public List<Rent> GetListByPending()
    {
        User user = _userService.GetById(FeUserSignInMenu.personId);

        if (user.Auth.Role != ERole.USER)
            throw new UserAccessOnlyException();

        List<Rent> giveBacks = _repository.GetListByPending(user.Id);

        if (giveBacks.Count == 0)
            throw new PendingGiveBackRequestsNotFoundException();

        return giveBacks;
    }

    public List<Rent> GetListByRejected()
    {
        User user = _userService.GetById(FeUserSignInMenu.personId);

        if (user.Auth.Role != ERole.USER)
            throw new UserAccessOnlyException();

        List<Rent> giveBacks = _repository.GetListByRejected(user.Id);

        if (giveBacks.Count == 0)
            throw new RejectedGiveBackRequestsNotFoundException();

        return giveBacks;
    }

    public List<Rent> GetListByApprovedOrRejected()
    {
        User user = _userService.GetById(FeUserSignInMenu.personId);

        if (user.Auth.Role != ERole.USER)
            throw new UserAccessOnlyException();

        List<Rent> giveBacks = _repository.GetListByApprovedOrRejected(user.Id);

        if (giveBacks.Count == 0)
            throw new GiveBackHistoryNotFoundException();

        return giveBacks;
    }

    public List<Rent> GetListByPendingAll()
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.PersonId);

        if (admin.Auth.Role == ERole.USER)
            throw new AdminAccessOnlyException();

        List<Rent> giveBacks = _repository.GetListByPendingAll();

        if (giveBacks.Count == 0)
            throw new PendingGiveBackRequestsNotFoundException();

        return giveBacks;
    }

    public List<Rent> GetListByAdminDecision()
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.PersonId);

        if (admin.Auth.Role != ERole.SUPERADMIN)
            throw new SuperAdminAccessOnlyException();

        List<Rent> giveBacks = _repository.GetListByAdminDecision();

        if (giveBacks.Count == 0)
            throw new RentalHistoryNotFoundException();

        return giveBacks;
    }

    public void SendRequest(long rentId)
    {
        User user = _userService.GetById(FeUserSignInMenu.personId);

        if (user.Auth.Role != ERole.USER)
            throw new UserAccessOnlyException();

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
        Admin admin = _adminService.GetById(FeAdminSignInMenu.PersonId);

        if (admin.Auth.Role == ERole.USER)
            throw new AdminAccessOnlyException();

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
            ClothingItem cl = _clothingItemService.GetById(item.ClothingItem.Id);
            cl.StockCount += item.Quantity;
        }

        _repository.ApproveRequest();
    }

    public void RejectRequest(long rentId)
    {
        Admin admin = _adminService.GetById(FeAdminSignInMenu.PersonId);

        if (admin.Auth.Role == ERole.USER)
            throw new AdminAccessOnlyException();

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
