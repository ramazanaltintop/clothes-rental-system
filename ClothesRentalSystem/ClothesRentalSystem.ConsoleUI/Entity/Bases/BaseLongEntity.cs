namespace ClothesRentalSystem.ConsoleUI.Entity.Bases;

public class BaseLongEntity
{
    public long Id { get; set; }

    public override string ToString()
    {
        return $"Id : {Id}";
    }
}
