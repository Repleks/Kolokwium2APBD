using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrzykladoweGago.Models;

[Table("Sailboat")]
public class Sailboat
{
    [Key]
    [Required]
    [Column("IdSailboat")]
    public int IdSailboat { get; set; }

    [Required]
    [Column("Name")]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [Column("Capacity")]
    public int Capacity { get; set; }

    [Required]
    [Column("Description")]
    [MaxLength(100)]
    public string Description { get; set; }
    
    [Required]
    [Column("Price", TypeName = "money")]
    public double Price { get; set; }
    
    [Required]
    [ForeignKey("BoatStandard")]
    public int IdBoatStandard { get; set; }
    
    public BoatStandard BoatStandard { get; set; }
    

    public IEnumerable<SailboatReservation> SailboatReservations { get; set; }
}