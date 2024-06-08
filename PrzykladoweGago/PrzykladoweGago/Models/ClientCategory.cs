using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrzykladoweGago.Models;

public class ClientCategory
{
    [Key]
    [Required]
    [Column("IdClientCategory")]
    public int IdClientCategory { get; set; }
    
    [Required]
    [MaxLength(100)]
    [Column("Name")]
    public string Name { get; set; }
    
    [Required]
    [Column("DiscountPerc")]
    public double DiscountPerc { get; set; }
    
    public IEnumerable<Client> Clients { get; set; }
    
}