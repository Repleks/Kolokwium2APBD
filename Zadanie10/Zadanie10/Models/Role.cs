using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zadanie10.Models;

[Table("Roles")]
public class Role
{
    [Key]
    [Required]
    [Column("PK_role")]
    public int RoleId { get; set; }
    
    [Required]
    [Column("name")]
    [MaxLength(100)]
    public string RoleName { get; set; }
    
    public IEnumerable<Account> Accounts { get; set; }
}