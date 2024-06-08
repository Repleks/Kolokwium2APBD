using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrzykladoweGago.Models;

public class Client
{
    [Key]
    [Required]
    [Column("IdClient")]
    public int IdClient { get; set; }
    
    [Required]
    [Column("Name")]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Required]
    [Column("LastName")]
    [MaxLength(100)]
    public string LastName { get; set; }
    
    [Required]
    [Column("Birthday")]
    public DateTime Birthday { get; set; }
    
    [Required]
    [Column("Pesel")]
    [MaxLength(100)]
    public string Pesel { get; set; }
    
    [Required]
    [Column("Email")]
    [MaxLength(100)]
    public string Email { get; set; }
    
    [Required]
    [ForeignKey("ClientCategory")]
    public int IdClientCategory { get; set; }
    
    public ClientCategory ClientCategory { get; set; }
    
    public IEnumerable<Reservation> Reservations { get; set; }
    
}