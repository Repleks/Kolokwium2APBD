using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zadanie10.Models;

[Table("Products")]
public class Product
{
    [Key]
    [Required]
    [Column("PK_product")]
    public int ProductId { get; set; }
    
    [Required]
    [Column("name")]
    [MaxLength(100)]
    public string ProductName { get; set; }
    
    [Required]
    [Column("weight", TypeName = "decimal(5,2)")]
    public double Weight { get; set; }
    
    [Required]
    [Column("width", TypeName = "decimal(5,2)")]
    public double Width { get; set; }
    
    [Required]
    [Column("height", TypeName = "decimal(5,2)")]
    public double Height { get; set; }
    
    [Required]
    [Column("depth", TypeName = "decimal(5,2)")]
    public double Depth { get; set; }
    
    public IEnumerable<ProductCategory> ProductCategories { get; set; }
    
    public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }
}