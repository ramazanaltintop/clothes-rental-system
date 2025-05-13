using System.Text;
using ClothesRentalSystem.Entity.Base;
using ClothesRentalSystem.Entity.Enum;

namespace ClothesRentalSystem.Entity;

public class Rent : BaseEntity
{
    public string FicheName => $"fiche-{Id}";
    public ECondition ReturnStatus { get; set; } = ECondition.FALSE;
    public ECondition ApprovalStatus { get; set; } = ECondition.FALSE;
    public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    public User User { get; set; } = default!;
    public User? RentalApprovedBy { get; set; }
    public User? ReturnApprovedBy { get; set; }
    public decimal NetPrice { get; set; }

    public override string ToString()
    {
        StringBuilder cartItems = new StringBuilder();

        CartItems.ForEach(cartItem => cartItems.Append(cartItem.ToString()));

        return base.ToString() +
            $"Fiche Name : {FicheName}\n" +
            $"Username : {User.Auth.Username}\n" +
            $"CartItems : \n{cartItems}\n" +
            $"Net Price : {NetPrice:C}\n" +
            $"Return Status : {ReturnStatus.ToString()}\n" +
            $"Approval Status : {ApprovalStatus.ToString()}\n" +
            (RentalApprovedBy is not null ? $"Rental Approved By : {RentalApprovedBy.Auth.Username}\n" : "") +
            (ReturnApprovedBy is not null ? $"Return Approved By : {ReturnApprovedBy.Auth.Username}\n" : "");
    }
}
