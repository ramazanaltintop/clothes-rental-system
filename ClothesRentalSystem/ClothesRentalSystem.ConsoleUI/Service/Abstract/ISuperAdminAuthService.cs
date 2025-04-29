namespace ClothesRentalSystem.ConsoleUI.Service.Abstract;

public interface ISuperAdminAuthService
{
    bool HasSuperAdmin(long peopleId);
}
