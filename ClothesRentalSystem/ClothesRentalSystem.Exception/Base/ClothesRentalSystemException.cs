namespace ClothesRentalSystem.Exception.Base;

public abstract class ClothesRentalSystemException : SystemException
{
    protected ClothesRentalSystemException(string message) : base(message) { }
}
