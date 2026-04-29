namespace OpexBackend.Api.Dtos;

public class UpdateDeliveryRequest
{
    public string? ReceiverName { get; set; }

    public string? ReceiverNotes { get; set; }

    public List<UpdateDeliveryLineRequest> Lines
        { get; set; } = new();
}

public class UpdateDeliveryLineRequest
{
    public int LineId { get; set; }

    public decimal QuantityDelivered { get; set; }

    public decimal QuantityReturned { get; set; }

    public decimal QuantityRejected { get; set; }
}