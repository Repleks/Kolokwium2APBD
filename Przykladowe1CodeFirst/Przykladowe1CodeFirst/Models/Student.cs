using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Przykladowe1CodeFirst.Models;

[Table("Students")]
public class Student
{
    [Key]
    [Required]
    [Column("ID")]
    public int StudentId { get; set; }
    
    [Required]
    [Column("FirstName")]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [Required]
    [Column("LastName")]
    [MaxLength(50)]
    public string LastName { get; set; }
    
    [Required]
    [Column("Phone")]
    [MaxLength(9)]
    [Phone]
    public string Phone { get; set; }
    
    [Required]
    [Column("Birthdate")]
    public DateTime Birthdate { get; set; }
    
    public IEnumerable<GroupAssignment> GroupAssignments { get; set; }
}