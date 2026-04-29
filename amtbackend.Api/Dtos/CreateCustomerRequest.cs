namespace OpexBackend.Api.Dtos;

public class CreateCustomerRequest
{
    public string CustomerCode { get; set; } = "";
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string Pin { get; set; } = "";
}