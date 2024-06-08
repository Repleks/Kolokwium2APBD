using System.ComponentModel.DataAnnotations;

namespace PrzykladoweGago.Models;

public class BoatStandard
{
    [Key]
    [Required]
    public int IdBoatStandard { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Required]
    public int Level { get; set; }
    
    public IEnumerable<Sailboat> Sailboats { get; set; }
    
    public IEnumerable<Reservation> Reservations { get; set; }
 }