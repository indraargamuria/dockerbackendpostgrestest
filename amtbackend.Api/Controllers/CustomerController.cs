using Microsoft.AspNetCore.Mvc;
using OpexBackend.Api.Data;
using OpexBackend.Api.Dtos;
using OpexBackend.Api.Models;

namespace OpexBackend.Api.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomersController : ControllerBase
{
    private readonly AppDbContext _db;

    public CustomersController(
        AppDbContext db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateCustomerRequest request)
    {
        var customer = new Customer
        {
            CustomerCode = request.CustomerCode,
            Name = request.Name
        };

        _db.Customers.Add(customer);

        await _db.SaveChangesAsync();

        return Created(
            $"/api/customers/{customer.Id}",
            customer);
    }
}