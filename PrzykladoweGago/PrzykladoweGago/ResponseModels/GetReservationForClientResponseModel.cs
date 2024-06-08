namespace PrzykladoweGago.ResponseModels;

public class GetReservationForClientResponseModel
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
    public string Pesel { get; set; }
    public string Email { get; set; }
    public List<ReservationResponseModel> Reservations { get; set; }
}
public class ReservationResponseModel
{
    public int IdReservation { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int IdBoatStandard { get; set; }
    public int Capacity { get; set; }
    public int NumOfBoats { get; set; }
    public bool Fulfilled { get; set; }
    public double Price { get; set; }
    public string CancelReason { get; set; }
}