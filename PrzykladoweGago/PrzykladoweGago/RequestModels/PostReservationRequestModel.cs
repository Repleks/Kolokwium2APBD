using System.ComponentModel.DataAnnotations;

namespace PrzykladoweGago.RequestModels;

public class PostReservationRequestModel
{
    [Required]
    public int IdClient { get; set; }
    
    [Required]
    public DateTime DateFrom { get; set; }
    
    [Required]
    public DateTime DateTo { get; set; }
    
    [Required]
    public int IdBoatStandard { get; set; }
    
    [Required]
    public int NumOfBoats { get; set; }
}