namespace ClothesRentalSystem.ConsoleUI.Entity.Base;

public abstract class BaseEntity<T>
{
    public T Id { get; set; }

    public override string ToString()
    {
        return $"Id : {Id}\n";
    }
}
