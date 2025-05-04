namespace ClothesRentalSystem.ConsoleUI.Entity.Base;

public class BasePersonEntity : BaseEntity<long>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public DateTime BirthDate { get; set; }

    public override string ToString()
    {
        return base.ToString() +
            $"Full Name: {FullName}\n" +
            $"Birth Date: {BirthDate}\n";
    }
}
