using ClothesRentalSystem.Entity;
using ClothesRentalSystem.Entity.Enum;

namespace ClothesRentalSystem.Repository;

public class RentRepository : List
{
    public void AddToCart(CartItem cartItem)
    {
        Cart.Add(cartItem);
    }

    public List<Rent> GetListByUsername(string username)
    {
        return Rents.Where(rent => rent.User.Auth.Username.Equals(username)).ToList();
    }

    public List<Rent> GetListByApproved(long userId)
    {
        return Rents
            .Where(rent =>
                rent.User.Id == userId &&
                rent.ApprovalStatus == ECondition.APPROVED)
            .ToList();
    }

    public List<Rent> GetListByPending(long? userId = null)
    {
        var query = Rents.Where(rent =>
            rent.ApprovalStatus == ECondition.REQUESTED);

        if (userId.HasValue)
        {
            query = query.Where(rent => rent.User.Id == userId);
        }

        return query.ToList();
    }

    public List<Rent> GetListByRejected(long userId)
    {
        return Rents
            .Where(rent =>
                rent.User.Id == userId &&
                rent.ApprovalStatus == ECondition.REJECTED)
            .ToList();
    }

    public List<Rent> GetListByApprovedOrRejected(long userId)
    {
        return Rents.Where(rent =>
            rent.User.Id == userId &&
            (rent.ApprovalStatus == ECondition.APPROVED ||
            rent.ApprovalStatus == ECondition.REJECTED))
            .ToList();
    }

    public List<Rent> GetListByAdminDecision()
    {
        return Rents.Where(rent => rent.RentalApprovedBy is not null).ToList();
    }

    public Rent? GetById(long id)
    {
        return Rents.FirstOrDefault(rent => rent.Id == id);
    }

    public Rent? GetByFicheName(string ficheName)
    {
        return Rents.FirstOrDefault(rent => rent.FicheName.Equals(ficheName));
    }

    public List<CartItem> GetCart()
    {
        return Cart;
    }

    public CartItem? GetCartItemByClothingItemName(string clothingItemName)
    {
        return Cart.FirstOrDefault(item => item.ClothingItem.Name.Equals(clothingItemName));
    }

    public decimal GetTotalEarnings() => TotalEarnings;
    public void SetTotalEarnings(decimal rentalPrice)
    {
        TotalEarnings += rentalPrice;
    }

    public long GetTotalSales() => TotalSales;
    public void SetTotalSales(int quantity)
    {
        TotalSales += quantity;
    }

    public bool HasCartItem(string clothingItemName)
    {
        return Cart.Any(item => item.ClothingItem.Name.Equals(clothingItemName));
    }

    public void SendRequest(Rent rent)
    {
        Rents.Add(rent);
    }

    public bool ApproveRequest()
    {
        return true;
    }

    public bool RejectRequest()
    {
        return true;
    }

    public void ClearCart()
    {
        Cart.Clear();
    }
}