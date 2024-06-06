using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zadanie10.Models;

[Table("Accounts")]
public class Account
{
    [Key]
    [Required]
    [Column("PK_account")]
    public int AccountId { get; set; }
    
    [Required]
    [ForeignKey("Role")]
    [Column("FK_role")]
    public int RoleId { get; set; }
    
    public Role Role { get; set; }
    
    [Required]
    [Column("first_name")]
    [MaxLength(50)]
    public string UserFirstName { get; set; }
    
    [Required]
    [Column("last_name")]
    [MaxLength(50)]
    public string UserLastName { get; set; }
    
    [Required]
    [Column("email")]
    [MaxLength(80)]
    [EmailAddress]
    public string UserEmail { get; set; }
    
    [Column("phone")]
    [MaxLength(9)]
    [Phone]
    public string? UserPhone { get; set; }
    
    public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }
}