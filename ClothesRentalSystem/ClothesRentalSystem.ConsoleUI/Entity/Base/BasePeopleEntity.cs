namespace ClothesRentalSystem.ConsoleUI.Entity.Base;

public class BasePeopleEntity : BaseLongEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }

    public override string ToString()
    {
        return base.ToString() +
            $"First Name: {FirstName}\n" +
            $"Last Name: {LastName}\n" +
            $"Birth Date: {BirthDate}\n";
    }
}
