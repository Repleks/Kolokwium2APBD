using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PrzykladoweNumer2.Models;

public class Status
{
    [Required]
    [Key]
    [Column("ID")]
    public int StatusId { get; set; }
    
    [Required]
    [Column("Name")]
    [MaxLength(50)]
    public string Name { get; set; }
    
    public IEnumerable<Order> Orders { get; set; }
}