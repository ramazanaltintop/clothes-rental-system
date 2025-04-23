using ClothesRentalSystem.ConsoleUI.Entity.Base;
using ClothesRentalSystem.ConsoleUI.Entity.Enum;

namespace ClothesRentalSystem.ConsoleUI.Entity;

public class Rent : BaseLongEntity
{
    public byte Day { get; set; }
    public byte Quantity { get; set; }
    public ECondition GiveBack { get; set; } = ECondition.FALSE;
    public ECondition IsApproved { get; set; } = ECondition.FALSE;
    public Clothes Clothes { get; set; }
    public User User { get; set; }
    public decimal TotalPrice { get; set; }

    public override string ToString()
    {
        return base.ToString() +
            $"Username : {User.Auth.Username}\n" +
            $"Clothes : {Clothes.Name}\n" +
            $"Quantity : {Quantity}\n" +
            $"Day : {Day}\n" +
            $"Price : {Clothes.Price}\n" +
            $"Total Price : {TotalPrice}\n" +
            $"GiveBack : {GiveBack.ToString()}\n" +
            $"IsApproved : {IsApproved.ToString()}\n";
    }
}
