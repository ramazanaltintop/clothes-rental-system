using ClothesRentalSystem.Entity.Base;
using ClothesRentalSystem.Util;

namespace ClothesRentalSystem.Entity;

public class CartItem : BaseEntity
{
    public Rent? Rent { get; set; }
    public ClothingItem ClothingItem { get; set; } = default!;
    public byte Quantity { get; set; }
    public byte Day { get; set; }
    public decimal TotalPrice => Quantity * Day * ClothingItem.Price;

    public override string ToString()
    {
        return $"\t{HR.Get()}\n" +
            (Rent is not null ? $"\tRent Id : {Rent.Id}\n" : "") +
            $"\tClothing Item's Name : {ClothingItem.Name}\n" +
            $"\tQuantity : {Quantity}\n" +
            $"\tDay : {Day}\n" +
            $"\tUnit Price : {ClothingItem.Price:C}\n" +
            $"\tTotal Price : {TotalPrice:C}\n";
    }
}
