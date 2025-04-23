namespace ClothesRentalSystem.ConsoleUI.Entity.Base;

public class BaseShortEntity
{
    public short Id { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}\n";
    }
}
