using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PrzykladoweGago.Models;

/*
 * Problematyczna klasa która powoduje błąd w aplikacji przy migracji
 * Error Number:1785,State:0,Class:16
    Introducing FOREIGN KEY constraint 'FK_SailboatReservation_Sailboat_IdSailboat' on table 'SailboatReservati
    on' may cause cycles or multiple cascade paths. Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints.
    Could not create constraint or index. See previous errors.
    Treść błędu i numer
    
    Tymczasowe rozwiązanie w DatabaseContext metoda OnModelCreating
 */

[Table("SailboatReservation")]
[PrimaryKey("IdSailboat", "IdReservation")]
public class SailboatReservation
{
    [Key]
    [ForeignKey("Sailboat")]
    [Column("IdSailboat")]
    [Required]
    public int IdSailboat { get; set; }
    
    public Sailboat Sailboat { get; set; }
    
    [Key]
    [ForeignKey("Reservation")]
    [Column("IdReservation")]
    [Required]
    public int IdReservation { get; set; }
    
    public Reservation Reservation { get; set; }
    
}