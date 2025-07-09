# Bulky3 - Book Management System

A modern ASP.NET Core web application for managing books and categories with an admin interface and customer-facing views.

## 🚀 Features

- **Book Management**: Add, edit, delete, and view books with detailed information
- **Category Management**: Organize books into categories with display order
- **Admin Area**: Secure administrative interface for managing content
- **Customer Area**: Public-facing interface for browsing books
- **Entity Framework Core**: Modern data access with SQL Server
- **Repository Pattern**: Clean separation of data access logic
- **Responsive Design**: Bootstrap-based UI for all devices

## 🏗️ Architecture

This project follows a clean architecture pattern with the following structure:

```
Bulky3/
├── Bulky.DataAccess/          # Data access layer
│   ├── Data/                  # DbContext and configurations
│   ├── Repository/            # Repository implementations
│   └── Migrations/            # Entity Framework migrations
├── Bulky.Models/              # Domain models
├── Bulky.Utility/             # Utility classes and helpers
└── BulkyWeb3/                 # Web application
    ├── Areas/                 # MVC areas (Admin/Customer)
    ├── Controllers/           # MVC controllers
    ├── Views/                 # Razor views
    └── wwwroot/              # Static files (CSS, JS, images)
```

## 📋 Prerequisites

- .NET 8.0 SDK
- SQL Server (LocalDB, Express, or full version)
- Visual Studio 2022 or VS Code

## 🛠️ Installation & Setup

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd Bulky3
   ```

2. **Configure the database connection**
   - Open `BulkyWeb3/appsettings.json`
   - Update the connection string in `BulkyWeb3Connection` to match your SQL Server instance

3. **Run Entity Framework migrations**
   ```bash
   cd BulkyWeb3
   dotnet ef database update
   ```

4. **Build and run the application**
   ```bash
   dotnet build
   dotnet run
   ```

5. **Access the application**
   - Customer area: `https://localhost:5001` or `http://localhost:5000`
   - Admin area: `https://localhost:5001/Admin` or `http://localhost:5000/Admin`

## 📚 Data Models

### Product (Book)
- **Title**: Book title (required, max 255 characters)
- **Description**: Book description (required)
- **Author**: Book author (required, max 100 characters)
- **ISBN**: International Standard Book Number (required, max 20 characters)
- **ListPrice**: Original list price (required, range 0-10000)
- **Price**: Price for 1-50 copies (required, range 0-10000)
- **Price50**: Price for 50+ copies (required, range 0-10000)
- **Price100**: Price for 100+ copies (required, range 0-10000)
- **ImageUrl**: Optional book cover image URL
- **CategoryId**: Foreign key to Category
- **CreatedDate**: Timestamp of creation
- **IsActive**: Active status flag

### Category
- **Name**: Category name (required, max 255 characters)
- **DisplayOrder**: Order for display purposes (range 1-255)
- **CreatedDate**: Timestamp of creation
- **IsActive**: Active status flag
- **Products**: Navigation property to related products

## 🔧 Technologies Used

- **.NET 8.0**: Latest LTS version of .NET
- **ASP.NET Core MVC**: Web framework with Model-View-Controller pattern
- **Entity Framework Core**: Object-relational mapping (ORM)
- **SQL Server**: Database management system
- **Bootstrap**: CSS framework for responsive design
- **jQuery**: JavaScript library for DOM manipulation
- **Repository Pattern**: Design pattern for data access abstraction

## 📁 Project Structure

### Bulky.DataAccess
- **ApplicationDbContext.cs**: Entity Framework DbContext
- **Repository/**: Repository implementations and interfaces
- **Migrations/**: Database migration files

### Bulky.Models
- **Product.cs**: Book entity model
- **Category.cs**: Category entity model

### BulkyWeb3
- **Areas/Admin/**: Administrative interface
- **Areas/Customer/**: Customer-facing interface
- **Controllers/**: MVC controllers
- **Views/**: Razor view templates
- **wwwroot/**: Static files (CSS, JavaScript, images)

## 🚀 Getting Started

1. **Add Categories**: Use the admin interface to create book categories
2. **Add Books**: Create books and assign them to categories
3. **Manage Content**: Edit, delete, or deactivate books and categories as needed
4. **Customer View**: Browse books in the customer area

## 🔒 Security

- Admin area requires authentication (to be implemented)
- Input validation on all forms
- SQL injection protection through Entity Framework
- XSS protection through ASP.NET Core's built-in security features

## 📝 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📞 Support

For support and questions, please open an issue in the repository or contact the development team.

---

**Note**: This is a development project. For production use, ensure proper security measures, error handling, and performance optimizations are implemented. 