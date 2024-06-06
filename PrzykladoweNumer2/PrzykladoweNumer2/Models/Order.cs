using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PrzykladoweNumer2.Models;

public class Order
{
    [Key]
    [Column("ID")]
    public int OrderId { get; set; }
    
    [Required]
    [Column("CreatedAt")]
    public DateTime CreatedAt { get; set; }
    
    [Column("FinishedAt")]
    public DateTime? FinishedAt { get; set; }
    
    [Required]
    [Column("ClientID")]
    public int ClientId { get; set; }
    
    public Client Client { get; set; }
    
    [Required]
    [Column("StatusID")]
    public int StatusId { get; set; }
    
    public Status Status { get; set; }
    
    public IEnumerable<Product_Order> ProductOrders { get; set; }
    
}