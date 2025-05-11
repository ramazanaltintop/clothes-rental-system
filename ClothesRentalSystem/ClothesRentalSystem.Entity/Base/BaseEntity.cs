namespace ClothesRentalSystem.Entity.Base;

public abstract class BaseEntity<T>
{
    public T Id { get; set; } = default!;

    public override string ToString()
    {
        return $"Id : {Id}\n";
    }
}
