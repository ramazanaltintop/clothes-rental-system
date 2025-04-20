namespace ClothesRentalSystem.ConsoleUI.Entity.Bases;

public class BaseShortEntity
{
    public short Id { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}";
    }
}
