using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace PrzykladoweGago.Models;

[Table("Reservation")]
public class Reservation
{
    [Key]
    [Required]
    [Column("IdReservation")]
    public int IdReservation { get; set; }
    
    [Required]
    [Column("IdClient")]
    [ForeignKey("Client")]
    public int IdClient { get; set; }
    
    public Client Client { get; set; }
    
    [Required]
    [Column("DateFrom")]
    public DateTime DateFrom { get; set; }
    
    [Required]
    [Column("DateTo")]
    public DateTime DateTo { get; set; }
    
    [Required]
    [Column("IdBoatStandard")]
    [ForeignKey("BoatStandard")]
    public int IdBoatStandard { get; set; }
    
    public BoatStandard BoatStandard { get; set; }
    
    [Required]
    [Column("Capacity")]
    public int Capacity { get; set; }
    
    [Required]
    [Column("NumOfBoats")]
    public int NumOfBoats { get; set; }
    
    [Required]
    [Column("Fulfilled", TypeName = "bit")]
    public bool Fulfilled { get; set; }
    
    [Column("Price", TypeName = "money")]
    public double Price { get; set; }
    
    [Column("CancelReason")]
    [MaxLength(200)]
    public string CancelReason { get; set; }
    
    public IEnumerable<SailboatReservation> SailboatReservations { get; set; }
    
    
}