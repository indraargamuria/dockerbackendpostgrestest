namespace OpexBackend.Api.Models;

public class DeliveryLine
{
    public int Id { get; set; }

    public int DeliveryHeaderId { get; set; }

    public DeliveryHeader DeliveryHeader { get; set; } = null!;

    public string ItemCode { get; set; } = "";

    public decimal Quantity { get; set; }
    
    public decimal QuantityDelivered { get; set; }

    public decimal QuantityReturned { get; set; }

    public decimal QuantityRejected { get; set; }
    //Test
}