using Microsoft.EntityFrameworkCore;
using PrzykladoweNumer2.Models;

namespace PrzykladoweNumer2.Context;

public class DatabaseContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    
    public DbSet<Order> Orders { get; set; }
    
    public DbSet<Product> Products { get; set; }
    
    public DbSet<Product_Order> ProductOrders { get; set; }
    
    public DbSet<Status> Statuses { get; set; }

    protected DatabaseContext()
    {
        
    }
    
    public DatabaseContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Client>().HasData(new Client
        {
            ClientId = 1,
            FirstName = "Jan",
            LastName = "Kowalski",
        });

        modelBuilder.Entity<Status>().HasData(new Status
        {
            StatusId = 1,
            Name = "Test"
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 1,
            Name = "Test",
            Price = 10.0m
        });

        modelBuilder.Entity<Order>().HasData(new Order
        {
            OrderId = 1,
            CreatedAt = DateTime.Now,
            ClientId = 1,
            StatusId = 1
        });

        modelBuilder.Entity<Product_Order>().HasData(new Product_Order
        {
            ProductId = 1,
            OrderId = 1,
            Amount = 1
        });
        
    }
}
