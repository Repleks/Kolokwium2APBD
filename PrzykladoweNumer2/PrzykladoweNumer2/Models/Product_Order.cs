using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PrzykladoweNumer2.Models;
[PrimaryKey("ProductId", "OrderId")]
public class Product_Order
{
    
    [Key]
    [ForeignKey("Product")]
    [Column("ProductId")]
    [Required]
    public int ProductId { get; set; }
    
    public Product Product { get; set; }
    
    [Key]
    [ForeignKey("Order")]
    [Column("OrderId")]
    [Required]
    public int OrderId { get; set; }
    
    public Order Order { get; set; }
    
    [Column("Amount")]
    [Required]
    public int Amount { get; set; }
    
}