using Microsoft.EntityFrameworkCore;
using PrzykladoweGago.Models;

namespace PrzykladoweGago.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<BoatStandard> BoatStandards { get; set; }
    
    public DbSet<Reservation> Reservations { get; set; }
    
    public DbSet<Sailboat> Sailboats { get; set; }
    
    public DbSet<Client> Clients { get; set; }
    
    public DbSet<ClientCategory> ClientCategories { get; set; }
    
    public DbSet<SailboatReservation> SailboatReservations { get; set; }
    
    protected DatabaseContext()
    {
    }
    
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        //blokowanie usuwania kaskadowego na tabelach w bazie danych
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
        
        
        modelBuilder.Entity<ClientCategory>().HasData(new ClientCategory
        {
            IdClientCategory = 1,
            Name = "Test",
            DiscountPerc = 10.0
        });
        
        modelBuilder.Entity<Client>().HasData(new Client
        {
            IdClient = 1,
            Name = "Jan",
            LastName = "Kowalski",
            Birthday = DateTime.Now,
            Pesel = "12345678901",
            Email = "jankowalski@gmail.com",
            IdClientCategory = 1 
        });
        
        modelBuilder.Entity<BoatStandard>().HasData(new BoatStandard
        {
            IdBoatStandard = 1,
            Name = "Test",
            Level = 1
        });
        
        modelBuilder.Entity<Sailboat>().HasData(new Sailboat
        {
            IdSailboat = 1,
            Name = "Test",
            Capacity = 10,
            Description = "Test",
            IdBoatStandard = 1,
            Price = 100.0
        });
        
        modelBuilder.Entity<Reservation>().HasData(new Reservation
        {
            IdReservation = 1,
            IdClient = 1,
            DateFrom = DateTime.Now,
            DateTo = DateTime.Now,
            IdBoatStandard = 1,
            Capacity = 1,
            NumOfBoats = 1,
            Fulfilled = false,
            Price = 1.0,
            CancelReason = "Test"
        });
        
        modelBuilder.Entity<SailboatReservation>().HasData(new SailboatReservation
        {
            IdSailboat = 1,
            IdReservation = 1
        });
        
        
            
    }
}