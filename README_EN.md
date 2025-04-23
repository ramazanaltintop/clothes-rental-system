# 👗 Clothes Rental System

A console-based clothes rental management application built using **Layered Architecture** in C#. This system enables **users** to browse, rent, and give back clothes, while allowing **admins** to manage clothing inventory, rental requests, and user activity.

---

## 🧱 Project Architecture

This project follows a **Layered Architecture** approach to ensure maintainability and scalability, with clearly defined responsibilities for each layer:

```
ClothesRentalSystem.ConsoleUI
│
├── Entity/                 # Domain Models and Enums
│   ├── Base/               # Generic base entity classes
│   ├── Enum/               # Enums like RoleType, RentalStatus, etc.
│   ├── Admin.cs
│   ├── Auth.cs
│   ├── Category.cs
│   ├── Clothes.cs
│   ├── Rent.cs
│   └── User.cs
│
├── Presentation/           # Controllers: Bridge between UI and Business Logic
│   ├── AuthController/
│   │   ├── AdminAuthController.cs
│   │   └── UserAuthController.cs
│   ├── RentingController/
│   │   ├── GiveBackController.cs
│   │   └── RentController.cs
│   ├── AdminController.cs
│   ├── CategoryController.cs
│   ├── ClothesController.cs
│   └── UserController.cs
│
├── Repository/             # Data Access Layer: CRUD operations
│   ├── RentingRepository/
│   │   ├── GiveBackRepository.cs
│   │   └── RentRepository.cs
│   ├── AdminRepository.cs
│   ├── AuthRepository.cs
│   ├── CategoryRepository.cs
│   ├── ClothesRepository.cs
│   ├── List.cs             # In-memory mock data
│   └── UserRepository.cs
│
├── Service/                # Business Logic Layer
│   ├── Abstract/           # Interfaces
│   │   ├── IAdminService.cs
│   │   ├── IAuthService.cs
│   │   ├── ICategoryService.cs
│   │   ├── IClothesService.cs
│   │   ├── IGiveBackService.cs
│   │   ├── IRentService.cs
│   │   └── IUserService.cs
│   └── Concrete/           # Implementations
│       ├── AuthServiceImpl/
│       │   ├── AdminAuthServiceImpl.cs
│       │   └── UserAuthServiceImpl.cs
│       ├── RentingServiceImpl/
│       │   ├── GiveBackServiceImpl.cs
│       │   └── RentServiceImpl.cs
│       ├── AdminServiceImpl.cs
│       ├── CategoryServiceImpl.cs
│       ├── ClothesServiceImpl.cs
│       └── UserServiceImpl.cs
│
├── Util/                   # Helper Classes
│   └── GenerateId.cs       # Utility to generate unique IDs
│
├── Fe*.cs                  # Console-based Front-End simulation
│   ├── FeAdminLogin.cs
│   ├── FeAdminMenu.cs
│   ├── FeClothesRentalSystem.cs
│   ├── FeClothingMenu.cs
│   ├── FeGiveBackMenu.cs
│   ├── FeRentMenu.cs
│   ├── FeUserLogin.cs
│   └── FeUserMenu.cs
│
├── Program.cs              # Entry point of the application
└── SeedData.cs             # Populates initial mock data
```

---

## 🎮 Menu Flow

```
1. User Login
    ├─ 1. Sign-in with Username
    ├─ 2. Sign-in with Email
    └─ 3. Return to Main Menu

    ✅ If login is successful:
    ├─ 1. Clothing Menu
    │   ├─ View All Clothes
    │   ├─ View Clothes by Category
    │   ├─ View Available Clothes
    │   ├─ View Most Rented Clothes
    │   └─ Back to Previous Menu
    ├─ 2. Rental Menu
    │   ├─ Create Rental Request
    │   ├─ View Past Rental Requests
    │   ├─ View Approved Rental Requests
    │   ├─ View Rejected Rental Requests
    │   ├─ View Pending Rental Requests
    │   └─ Back to Previous Menu
    ├─ 3. Give Back Menu
    │   ├─ Create Give Back Request
    │   ├─ View Past Give Back Requests
    │   ├─ View Approved Give Back Requests
    │   ├─ View Rejected Give Back Requests
    │   ├─ View Pending Give Back Requests
    │   └─ Back to Previous Menu
    └─ 4. Log Out

2. Admin Login
    ├─ 1. Sign-in with Username
    ├─ 2. Sign-in with Email
    └─ 3. Return to Main Menu

    ✅ If login is successful:
    ├─ Clothing Management
    │   ├─ Add / Remove Clothes
    │   ├─ View User Rental History
    │   ├─ Manage Rental & Give Back Requests (Approve / Reject)
    │   └─ Log Out

3. Exit
```

---

## 🚀 Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/ramazanaltintop/clothes-rental-system.git
   ```
2. Open the solution in Visual Studio.
3. Set `ClothesRentalSystem.ConsoleUI` as the startup project.
4. Run the application.

---

## 📌 Technologies Used

- C#
- .NET Core
- Console Application
- Layered Architecture
- In-Memory Storage (mocked DB)

---

## 📂 Future Improvements

- Add real database support (e.g., SQL Server, EF Core).
- Implement logging and error handling middleware.
- Develop a web-based front-end (ASP.NET Core MVC or Blazor).
- Add user registration & password management.
- Export reports for admins.

---

## 📄 License

This project is licensed under the MIT License. Feel free to use, modify, and distribute it for personal or educational purposes.