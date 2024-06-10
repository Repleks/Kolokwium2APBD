using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Przykladowe1CodeFirst.Models;

[Table("GroupAssignments")]
[PrimaryKey("GroupId", "StudentId")]
public class GroupAssignment
{
    [Key]
    [Required]
    [ForeignKey("Group")]
    [Column("GroupId")]
    public int GroupId { get; set; }
    
    public Group Group { get; set; }
    
    [Key]
    [Required]
    [ForeignKey("Student")]
    [Column("StudentId")]
    public int StudentId { get; set; }
    
    public Student Student { get; set; }
}