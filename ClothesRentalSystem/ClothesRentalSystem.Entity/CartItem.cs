using ClothesRentalSystem.Util;

namespace ClothesRentalSystem.Entity;

public class CartItem
{
    public Rent? Rent { get; set; }
    public ClothingItem ClothingItem { get; set; } = default!;
    public byte Quantity { get; set; }
    public byte Day { get; set; }
    public decimal TotalPrice { get; set; }

    public override string ToString()
    {
        return $"\t{HR.Get()}\n" +
            (Rent is not null ? $"\tRent Id : {Rent.Id}\n" : "") +
            $"\tClothing Item's Name : {ClothingItem.Name}\n" +
            $"\tQuantity : {Quantity}\n" +
            $"\tDay : {Day}\n" +
            $"\tUnit Price : ${ClothingItem.Price}\n" +
            $"\tTotal Price : ${TotalPrice}\n";
    }
}
