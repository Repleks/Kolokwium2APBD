using Microsoft.EntityFrameworkCore;
using Przykladowe1CodeFirst.Models;

namespace Przykladowe1CodeFirst.Context;

public class DatabaseContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    
    public DbSet<Group> Groups { get; set; }
    
    public DbSet<GroupAssignment> GroupAssignments { get; set; }
    
    protected DatabaseContext()
    {
    }
    
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        //create test data 
        modelBuilder.Entity<Student>().HasData(new Student
        {
            StudentId = 1,
            FirstName = "Jan",
            LastName = "Kowalski",
            Phone = "123456789",
            Birthdate = new DateTime(2000, 1, 1)
        });
        
        modelBuilder.Entity<Group>().HasData(new Group
        {
            GroupId = 1,
            Name = "Test"
        });
        
        modelBuilder.Entity<GroupAssignment>().HasData(new GroupAssignment
        {
            GroupId = 1,
            StudentId = 1
        });
        
    }
}