using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Zadanie10.Models;

[Table("ShoppingCarts")]
[PrimaryKey("AccountId", "ProductId")]
public class ShoppingCart
{
    [Key]
    [ForeignKey("Account")]
    [Column("FK_account")]
    [Required]
    public int AccountId { get; set; }

    public Account Account { get; set; }

    [Key]
    [ForeignKey("Product")]
    [Column("FK_product")]
    [Required]
    public int ProductId { get; set; }

    public Product Product { get; set; }
    
    [Column("Amount")]
    [Required]
    public int Amount { get; set; }
}