namespace OpexBackend.Api.Dtos;

public class CreateDeliveryRequest
{
    public string CustomerCode { get; set; } = "";

    public string DeliveryNumber { get; set; } = "";

    public DateTime DeliveryDate { get; set; }

    public List<CreateDeliveryLineRequest> Lines
        { get; set; } = new();
}

public class CreateDeliveryLineRequest
{
    public string ItemCode { get; set; } = "";

    public decimal Quantity { get; set; }
}