using Microsoft.EntityFrameworkCore;
using Zadanie10.Models;

namespace Zadanie10.Context;

public class DatabaseContext : DbContext
{
    public DbSet<Role> Roles { get; set; }
    
    public DbSet<Account> Accounts { get; set; }
    
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    
    public DbSet<Product> Products { get; set; }
    
    public DbSet<ProductCategory> ProductCategories { get; set; }
    
    public DbSet<Category> Categories { get; set; }
    
    protected DatabaseContext()
    {
    }
    
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = 1,
            CategoryName = "Test"
        });

        modelBuilder.Entity<Role>().HasData(new Role
        {
            RoleId = 1,
            RoleName = "User"
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 1,
            ProductName = "TestPName",
            Depth = 0.1,
            Height = 0.2,
            Weight = 0.3,
            Width = 0.4
        });

        modelBuilder.Entity<Account>().HasData(new Account
        {
            AccountId = 1,
            RoleId = 1,
            UserFirstName = "Jan",
            UserLastName = "Kowalski",
            UserEmail = "jankowalski@gmail.com",
            UserPhone = null
        });

        modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
        {
            ProductId = 1,
            CategoryId = 1
        });

        modelBuilder.Entity<ShoppingCart>().HasData(new ShoppingCart
        {
            ProductId = 1,
            AccountId = 1,
            Amount = 10
        });
    }
}