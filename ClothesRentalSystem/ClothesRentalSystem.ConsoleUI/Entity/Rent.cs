using System.Text;
using ClothesRentalSystem.ConsoleUI.Entity.Base;
using ClothesRentalSystem.ConsoleUI.Entity.Enum;

namespace ClothesRentalSystem.ConsoleUI.Entity;

public class Rent : BaseEntity<long>
{
    public ECondition GiveBack { get; set; } = ECondition.FALSE;
    public ECondition IsApproved { get; set; } = ECondition.FALSE;
    public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    public User User { get; set; } = default!;
    public Admin? RentalAdmin { get; set; }
    public Admin? GiveBackAdmin { get; set; }
    public decimal NetPrice { get; set; }

    public override string ToString()
    {
        StringBuilder cartItems = new StringBuilder();

        CartItems.ForEach(cartItem => cartItems.Append(cartItem.ToString()));

        return base.ToString() +
            $"Username : {User.Auth.Username}\n" +
            $"CartItems : \n{cartItems}\n" +
            $"Net Price : ${NetPrice}\n" +
            $"GiveBack : {GiveBack.ToString()}\n" +
            $"IsApproved : {IsApproved.ToString()}\n" +
            (RentalAdmin is not null ? $"Rental Decision By : {RentalAdmin.Auth.Username}\n" : "") +
            (GiveBackAdmin is not null ? $"Give Back Decision By : {GiveBackAdmin.Auth.Username}\n" : "");
    }
}
