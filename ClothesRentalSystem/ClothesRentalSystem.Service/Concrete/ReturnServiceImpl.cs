using ClothesRentalSystem.Entity.Enum;
using ClothesRentalSystem.Entity;
using ClothesRentalSystem.Service.Abstract;
using ClothesRentalSystem.Exception.AuthException;
using ClothesRentalSystem.Exception.ReturnException;
using ClothesRentalSystem.Repository;
using ClothesRentalSystem.Exception.RentalException;

namespace ClothesRentalSystem.Service.Concrete;

public class ReturnServiceImpl : IReturnService
{
    private readonly ReturnRepository _repository;
    private readonly IUserService _userService;
    private readonly IClothingItemService _clothingItemService;
    private readonly IRentService _rentService;

    public ReturnServiceImpl(ReturnRepository repository, IUserService userService, IClothingItemService clothingItemService, IRentService rentService)
    {
        _repository = repository;
        _userService = userService;
        _clothingItemService = clothingItemService;
        _rentService = rentService;
    }

    public List<Rent> GetListByUsername(string username)
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role == ERole.USER)
            throw new AdminAccessOnlyException();

        _userService.HasUsername(username);

        List<Rent> userReturns = _repository.GetListByUsername(username);

        if (userReturns.Count == 0)
            throw new ReturnNotFoundException();

        return userReturns;
    }

    public List<Rent> GetListByApproved()
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role != ERole.USER)
            throw new UserAccessOnlyException();

        List<Rent> approvedReturns = _repository.GetListByApproved(user.Id);

        if (approvedReturns.Count == 0)
            throw new ApprovedReturnRequestsNotFoundException();

        return approvedReturns;
    }

    public List<Rent> GetListByPending()
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role != ERole.USER)
            throw new UserAccessOnlyException();

        List<Rent> pendingReturns = _repository.GetListByPending(user.Id);

        if (pendingReturns.Count == 0)
            throw new PendingReturnRequestsNotFoundException();

        return pendingReturns;
    }

    public List<Rent> GetListByPendingAll()
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role == ERole.USER)
            throw new AdminAccessOnlyException();

        List<Rent> pendingReturns = _repository.GetListByPending();

        if (pendingReturns.Count == 0)
            throw new PendingReturnRequestsNotFoundException();

        return pendingReturns;
    }

    public List<Rent> GetListByRejected()
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role != ERole.USER)
            throw new UserAccessOnlyException();

        List<Rent> rejectedReturns = _repository.GetListByRejected(user.Id);

        if (rejectedReturns.Count == 0)
            throw new RejectedReturnRequestsNotFoundException();

        return rejectedReturns;
    }

    public List<Rent> GetListByApprovedOrRejected()
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role != ERole.USER)
            throw new UserAccessOnlyException();

        List<Rent> pastReturns = _repository.GetListByApprovedOrRejected(user.Id);

        if (pastReturns.Count == 0)
            throw new ReturnHistoryNotFoundException();

        return pastReturns;
    }

    public List<Rent> GetListByAdminDecision()
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role != ERole.SUPERADMIN)
            throw new SuperAdminAccessOnlyException();

        List<Rent> approvedReturns = _repository.GetListByAdminDecision();

        if (approvedReturns.Count == 0)
            throw new RentalHistoryNotFoundException();

        return approvedReturns;
    }

    public void SendRequest(string ficheName)
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role != ERole.USER)
            throw new UserAccessOnlyException();

        Rent rent = _rentService.GetByFicheName(ficheName);

        if (rent.ApprovalStatus != ECondition.APPROVED)
            throw new ReturnRequestNotAllowedException();

        if (rent.ReturnStatus == ECondition.REQUESTED)
            throw new ReturnRequestAlreadySentException();

        rent.ReturnStatus = ECondition.REQUESTED;

        _repository.SendRequest(rent);
    }

    public void ApproveRequest(string ficheName)
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role == ERole.USER)
            throw new AdminAccessOnlyException();

        Rent rent = _rentService.GetByFicheName(ficheName);

        if (rent.ReturnStatus != ECondition.REQUESTED)
            throw new ReturnRequestNotFoundException();

        if (rent.ReturnStatus == ECondition.APPROVED)
            throw new ReturnRequestAlreadyApprovedException();

        rent.ReturnStatus = ECondition.APPROVED;
        rent.ReturnApprovedBy = user;

        List<CartItem> items = rent.CartItems;

        foreach (CartItem item in items)
        {
            ClothingItem cl = _clothingItemService.GetById(item.ClothingItem.Id);
            cl.StockCount += item.Quantity;
        }

        _repository.ApproveRequest();
    }

    public void RejectRequest(string ficheName)
    {
        User user = _userService.GetById(List.UserId);

        if (user.Auth.Role == ERole.USER)
            throw new AdminAccessOnlyException();

        Rent rent = _rentService.GetByFicheName(ficheName);

        if (rent.ReturnStatus != ECondition.REQUESTED)
            throw new ReturnRequestNotFoundException();

        if (rent.ReturnStatus == ECondition.REJECTED)
            throw new ReturnRequestAlreadyRejectedException();

        rent.ReturnStatus = ECondition.REJECTED;
        rent.ReturnApprovedBy = user;

        _repository.RejectRequest();
    }
}
