namespace ClothesRentalSystem.Entity.Base;

public class BaseEntity
{
    public long Id { get; set; }

    public override string ToString()
    {
        return $"Id : {Id}\n";
    }
}
