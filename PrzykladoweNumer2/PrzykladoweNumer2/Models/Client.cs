using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrzykladoweNumer2.Models;

public class Client
{
    [Key]
    [Required]
    [Column("ID")]
    public int ClientId { get; set; }
    
    [Column("FirstName")]
    [MaxLength(50)]
    [Required]
    public string FirstName { get; set; }
    
    [Column("LastName")]
    [MaxLength(100)]
    [Required]
    public string LastName { get; set; }
    
    public IEnumerable<Order> Orders { get; set; }
}