namespace ClothesRentalSystem.ConsoleUI.Entity.Base;

public class BaseLongEntity
{
    public long Id { get; set; }

    public override string ToString()
    {
        return $"Id : {Id}\n";
    }
}
