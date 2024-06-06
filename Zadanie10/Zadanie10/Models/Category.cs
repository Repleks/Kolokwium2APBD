using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zadanie10.Models;

[Table("Categories")]
public class Category
{
    [Key]
    [Required]
    [Column("PK_category")]
    public int CategoryId { get; set; }
    
    [Required]
    [Column("name")]
    [MaxLength(100)]
    public string CategoryName { get; set; }
    
    public IEnumerable<ProductCategory> ProductCategories { get; set; }
}