namespace ClothesRentalSystem.ConsoleUI.Entity.Base;

public class BaseByteEntity
{
    public byte Id { get; set; }

    public override string ToString()
    {
        return $"Id : {Id}\n";
    }
}
