namespace ClothesRentalSystem.ConsoleUI.Entity;

public class CartItem
{
    public Rent? Rent { get; set; }
    public Clothes Clothes { get; set; }
    public byte Quantity { get; set; }
    public byte Day { get; set; }
    public decimal TotalPrice { get; set; }

    public override string ToString()
    {
        return $"\t{Program.HR}\n" +
            (Rent is not null ? $"\tRent Id : {Rent.Id}\n" : "") +
            $"\tClothes Name : {Clothes.Name}\n" +
            $"\tQuantity : {Quantity}\n" +
            $"\tDay : {Day}\n" +
            $"\tUnit Price : ${Clothes.Price}\n" +
            $"\tTotal Price : ${TotalPrice}\n";
    }
}
