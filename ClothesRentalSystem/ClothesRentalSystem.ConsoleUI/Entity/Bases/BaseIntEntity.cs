namespace ClothesRentalSystem.ConsoleUI.Entity.Bases;

public class BaseIntEntity
{
    public int Id { get; set; }

    public override string ToString()
    {
        return $"Id : {Id}\n";
    }
}
