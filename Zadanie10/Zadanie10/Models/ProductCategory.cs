using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Zadanie10.Models;

[Table("ProductsCategories")]
[PrimaryKey("ProductId", "CategoryId")]
public class ProductCategory
{
    [Key]
    [ForeignKey("Product")]
    [Column("FK_product")]
    [Required]
    public int ProductId { get; set; }

    public Product Product { get; set; }
    
    [Key]
    [ForeignKey("Category")]
    [Column("FK_category")]
    [Required]
    public int CategoryId { get; set; }

    public Category Category { get; set; }
}