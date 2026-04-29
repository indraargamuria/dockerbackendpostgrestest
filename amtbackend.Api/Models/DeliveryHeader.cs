namespace OpexBackend.Api.Models;

public class DeliveryHeader
{
    public int Id { get; set; }

    public Guid DeliveryToken { get; set; }

    public string DeliveryNumber { get; set; } = "";

    public DateTime DeliveryDate { get; set; }

    public int CustomerId { get; set; }

    public Customer Customer { get; set; } = null!;

    public ICollection<DeliveryLine> DeliveryLines
        { get; set; } = new List<DeliveryLine>();

    public string? ReceiverName { get; set; }

    public string? ReceiverNotes { get; set; }
}