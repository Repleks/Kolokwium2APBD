using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Przykladowe1CodeFirst.Models;

[Table("Groups")]
public class Group
{
    [Key]
    [Required]
    [Column("ID")]
    public int GroupId { get; set; }
    
    [Required]
    [Column("Name")]
    [MaxLength(50)]
    public string Name { get; set; }
    
    public IEnumerable<GroupAssignment> GroupAssignments { get; set; }
}