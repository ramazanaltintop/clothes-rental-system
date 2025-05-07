using ClothesRentalSystem.ConsoleUI.Entity;
using ClothesRentalSystem.ConsoleUI.Entity.Enum;

namespace ClothesRentalSystem.ConsoleUI.Repository;

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

    public List<Rent> GetListByApproved(long personId)
    {
        return Rents
            .Where(rent =>
                rent.User.Id == personId &&
                rent.IsApproved == ECondition.APPROVED)
            .ToList();
    }

    public List<Rent> GetListByPending(long personId)
    {
        return Rents
            .Where(rent =>
                rent.User.Id == personId &&
                rent.IsApproved == ECondition.REQUESTED)
            .ToList();
    }

    public List<Rent> GetListByRejected(long personId)
    {
        return Rents
            .Where(rent =>
                rent.User.Id == personId &&
                rent.IsApproved == ECondition.REJECTED)
            .ToList();
    }

    public List<Rent> GetListByApprovedOrRejected(long personId)
    {
        return Rents.Where(rent =>
            rent.User.Id == personId &&
            (rent.IsApproved == ECondition.APPROVED ||
            rent.IsApproved == ECondition.REJECTED))
            .ToList();
    }

    public List<Rent> GetListByPendingAll()
    {
        return Rents
            .Where(rent => rent.IsApproved == ECondition.REQUESTED)
            .ToList();
    }

    public List<Rent> GetListByAdminDecision()
    {
        return Rents.Where(rent => rent.RentalAdmin is not null).ToList();
    }

    public Rent? GetById(long id)
    {
        return Rents.FirstOrDefault(rent => rent.Id == id);
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
        Console.WriteLine("Rental request sent.");
        Rents.Add(rent);
    }

    public void ApproveRequest()
    {
        Console.WriteLine("Rental request approved.");
    }

    public void RejectRequest()
    {
        Console.WriteLine("Rental request rejected.");
    }

    public void ClearCart()
    {
        Cart.Clear();
        Console.WriteLine("Your cart successfully cleared.");
    }
}