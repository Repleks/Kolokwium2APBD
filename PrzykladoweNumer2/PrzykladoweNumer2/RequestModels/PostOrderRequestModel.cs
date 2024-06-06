using System.ComponentModel.DataAnnotations;

namespace PrzykladoweNumer2.RequestModels;

public class PostOrderRequestModel
{
    [Required]
    public DateTime createdAt { get; set; }
    public DateTime? finishedAt { get; set; }
    [Required]
    public List<PostOrderProduct> products { get; set; }
}
public class PostOrderProduct
{
    [Required]
    public int id { get; set; }
    [Required]
    public int amount { get; set; }
}