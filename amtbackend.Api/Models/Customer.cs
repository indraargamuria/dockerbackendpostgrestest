namespace OpexBackend.Api.Models;

public class Customer
{
    public int Id { get; set; }

    public string CustomerCode { get; set; } = "";

    public string Name { get; set; } = "";
    
    public string Email { get; set; } = "";
    
    public string Pin { get; set; } = "";

    public ICollection<DeliveryHeader> DeliveryHeaders
        { get; set; } = new List<DeliveryHeader>();
}