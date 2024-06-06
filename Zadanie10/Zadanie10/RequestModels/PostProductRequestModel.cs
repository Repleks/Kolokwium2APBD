using System.ComponentModel.DataAnnotations;

namespace Zadanie10.RequestModels;

public class PostProductRequestModel
{
    [Required]
    [MaxLength(100)]
    public string productName { get; set; }
    
    [Required]
    public double productWeight { get; set; }

    [Required]
    public double productWidth { get; set; }

    [Required]
    public double productHeight { get; set; }
    
    [Required]
    public double productDepth { get; set; }
    
    [Required]
    public List<int> categories { get; set; }
}