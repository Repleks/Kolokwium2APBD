using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrzykladoweNumer2.Models;

public class Product
{
    [Required]
    [Key]
    [Column("ID")]
    public int ProductId { get; set; }
    
    [Required]
    [Column("Name")]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    [Column("Price", TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }
    
    public IEnumerable<Product_Order> ProductOrders { get; set; }
}