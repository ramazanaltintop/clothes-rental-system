namespace ClothesRentalSystem.ConsoleUI.Entity.Base;

public class BaseIntEntity
{
    public int Id { get; set; }

    public override string ToString()
    {
        return $"Id : {Id}\n";
    }
}
