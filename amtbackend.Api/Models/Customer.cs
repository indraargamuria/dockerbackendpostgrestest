namespace OpexBackend.Api.Models;

public class Customer
{
    public int Id { get; set; }

    public string CustomerCode { get; set; } = "";

    public string Name { get; set; } = "";

    public ICollection<DeliveryHeader> DeliveryHeaders
        { get; set; } = new List<DeliveryHeader>();
}