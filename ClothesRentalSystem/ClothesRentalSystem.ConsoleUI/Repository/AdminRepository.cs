using ClothesRentalSystem.ConsoleUI.Entity;

namespace ClothesRentalSystem.ConsoleUI.Repository
{
    public class AdminRepository : List
    {
        public void Save(Admin admin)
        {
            admins.Add(admin);
        }

        public bool CheckUsername(string username)
        {
            return admins.Any(admin => admin.Username.Equals(username));
        }

        public bool CheckEmail(string email)
        {
            return admins.Any(admin => admin.Email.Equals(email));
        }
    }
}
