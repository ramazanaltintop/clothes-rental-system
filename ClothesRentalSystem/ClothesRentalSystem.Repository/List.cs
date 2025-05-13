using ClothesRentalSystem.Entity;
using ClothesRentalSystem.Entity.Enum;
using ClothesRentalSystem.Util;

namespace ClothesRentalSystem.Repository;

// Database Simulation
public class List
{
    protected static List<User> Users = new List<User>()
    {
        new User()
        {
            Id = GenerateId.GenerateUserId(),
            Auth = new Auth()
            {
                Id = GenerateId.GenerateAuthId(),
                Username = "super1",
                Email = "super1@hotmail.com",
                Password = "1",
                Role = ERole.SUPERADMIN,
            }
        },
        new User()
        {
            Id = GenerateId.GenerateUserId(),
            Auth = new Auth()
            {
                Id = GenerateId.GenerateAuthId(),
                Email = "admin1@hotmail.com",
                Username = "admin1",
                Password = "1",
                Role = ERole.ADMIN,
            }
        },
        new User()
        {
            Id = GenerateId.GenerateUserId(),
            Auth = new Auth()
            {
                Id = GenerateId.GenerateAuthId(),
                Email = "admin2@hotmail.com",
                Username = "admin2",
                Password = "2",
                Role = ERole.ADMIN,
            }
        },
        new User()
        {
            Id = GenerateId.GenerateUserId(),
            Auth = new Auth()
            {
                Id = GenerateId.GenerateAuthId(),
                Username = "user1",
                Email = "user1@hotmail.com",
                Password = "1",
                Role = ERole.USER,
            }
        },
        new User()
        {
            Id = GenerateId.GenerateUserId(),
            Auth = new Auth()
            {
                Id = GenerateId.GenerateAuthId(),
                Username = "user2",
                Email = "user2@hotmail.com",
                Password = "2",
                Role = ERole.USER,
            }
        },
        new User()
        {
            Id = GenerateId.GenerateUserId(),
            Auth = new Auth()
            {
                Id = GenerateId.GenerateAuthId(),
                Username = "user3",
                Email = "user3@hotmail.com",
                Password = "3",
                Role = ERole.USER,
            }
        }
    };
    protected static List<Category> Categories = new List<Category>()
    {
        new Category()
        {
            Id = GenerateId.GenerateCategoryId(),
            Name = "takim elbise"
        },
        new Category()
        {
            Id = GenerateId.GenerateCategoryId(),
            Name = "gomlek"
        },
        new Category()
        {
            Id = GenerateId.GenerateCategoryId(),
            Name = "pantolon"
        },
    };
    protected static List<ClothingItem> Clothes = new List<ClothingItem>()
    {
        new ClothingItem()
        {
            Id = GenerateId.GenerateClothingItemId(),
            Name = "beyaz takim elbise",
            Price = 500,
            StockCount = 13,
            Category = Categories.FirstOrDefault(category => category.Name.Equals("takim elbise"))!
        },
        new ClothingItem()
        {
            Id = GenerateId.GenerateClothingItemId(),
            Name = "siyah takim elbise",
            Price = 400,
            StockCount = 25,
            Category = Categories.FirstOrDefault(category => category.Name.Equals("takim elbise"))!
        },
        new ClothingItem()
        {
            Id = GenerateId.GenerateClothingItemId(),
            Name = "mavi takim elbise",
            Price = 300,
            StockCount = 36,
            Category = Categories.FirstOrDefault(category => category.Name.Equals("takim elbise"))!
        },
        new ClothingItem()
        {
            Id = GenerateId.GenerateClothingItemId(),
            Name = "beyaz gomlek",
            Price = 100,
            StockCount = 45,
            Category = Categories.FirstOrDefault(category => category.Name.Equals("gomlek"))!
        },
        new ClothingItem()
        {
            Id = GenerateId.GenerateClothingItemId(),
            Name = "siyah gomlek",
            Price = 100,
            StockCount = 45,
            Category = Categories.FirstOrDefault(category => category.Name.Equals("gomlek"))!
        },
        new ClothingItem()
        {
            Id = GenerateId.GenerateClothingItemId(),
            Name = "beyaz pantolon",
            Price = 200,
            StockCount = 0,
            Category = Categories.FirstOrDefault(category => category.Name.Equals("pantolon"))!
        },
        new ClothingItem()
        {
            Id = GenerateId.GenerateClothingItemId(),
            Name = "siyah pantolon",
            Price = 200,
            StockCount = 0,
            Category = Categories.FirstOrDefault(category => category.Name.Equals("pantolon"))!
        }
    };
    protected static List<Rent> Rents = new List<Rent>();
    protected List<CartItem> Cart = new List<CartItem>();
    protected static decimal TotalEarnings = 0m;
    protected static long TotalSales = 0;
    public static long UserId { get; set; }
}
