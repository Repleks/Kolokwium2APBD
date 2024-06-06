namespace PrzykladoweNumer2.ResponseModels;

public class GetOrderResponseModel
{
    public int OrderId { get; set; }
    public string clientsLastName { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime? finishedAt { get; set; }
    public string status { get; set; }
    public List<GetOrderProduct> products { get; set; }
}
public class GetOrderProduct
{
    public string productName { get; set; }
    public decimal price { get; set; }
    public int amount { get; set; }
}