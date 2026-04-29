using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpexBackend.Api.Data;
using OpexBackend.Api.Dtos;
using OpexBackend.Api.Models;

namespace OpexBackend.Api.Controllers;

[ApiController]
[Route("api/deliveries")]
public class DeliveriesController : ControllerBase
{
    private readonly AppDbContext _db;

    public DeliveriesController(
        AppDbContext db)
    {
        _db = db;
    }

    [HttpPatch("{token:guid}")]
    public async Task<IActionResult> UpdateDelivery(
        Guid token,
        UpdateDeliveryRequest request)
    {
        var delivery =
            await _db.DeliveryHeaders
                .Include(x=>x.DeliveryLines)
                .FirstOrDefaultAsync(
                    x=>x.DeliveryToken==token);

        if(delivery == null)
            return NotFound();

        delivery.ReceiverName =
            request.ReceiverName;

        delivery.ReceiverNotes =
            request.ReceiverNotes;

        foreach(var reqLine in request.Lines)
        {
            var line =
                delivery.DeliveryLines
                .FirstOrDefault(
                    x=>x.Id==reqLine.LineId);

            if(line == null)
                continue;

            line.QuantityDelivered =
                reqLine.QuantityDelivered;

            line.QuantityReturned =
                reqLine.QuantityReturned;

            line.QuantityRejected =
                reqLine.QuantityRejected;
        }

        await _db.SaveChangesAsync();

        return Ok(new
        {
            success=true,
            message="Delivery updated"
        });
    }
    [HttpGet("{token:guid}")]
    public async Task<IActionResult> GetByToken(
        Guid token)
    {
        var delivery =
            await _db.DeliveryHeaders
                .Include(x=>x.Customer)
                .Include(x=>x.DeliveryLines)
                .FirstOrDefaultAsync(
                   x=>x.DeliveryToken==token);

        if(delivery == null)
            return NotFound();

        return Ok(
            new
            {
               deliveryToken =
                   delivery.DeliveryToken,

               deliveryNumber =
                   delivery.DeliveryNumber,

               customerCode =
                   delivery.Customer.CustomerCode,

               customerName =
                   delivery.Customer.Name,

               deliveryDate =
                   delivery.DeliveryDate,

               lines = delivery.DeliveryLines
                   .Select(x=> new
                   {
                      itemCode=x.ItemCode,
                      quantity=x.Quantity
                   })
            });
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateDeliveryRequest request)
    {
        var customer =
            await _db.Customers
            .FirstOrDefaultAsync(
                x => x.CustomerCode == request.CustomerCode);
        // var customer =
        //     await _db.Customers
        //         .FirstOrDefaultAsync(
        //             x => x.Id == request.CustomerId);

        if(customer == null)
            return BadRequest("Customer not found");
        var token = Guid.NewGuid();
        var header = new DeliveryHeader
        {
            DeliveryToken = token,
            CustomerId = customer.Id,
            DeliveryNumber = request.DeliveryNumber,
            DeliveryDate = DateTime.SpecifyKind(
                request.DeliveryDate,
                DateTimeKind.Utc),
            DeliveryLines = request.Lines
                .Select(x =>
                    new DeliveryLine
                    {
                        ItemCode = x.ItemCode,
                        Quantity = x.Quantity
                    })
                .ToList()
        };

        _db.DeliveryHeaders.Add(header);

        await _db.SaveChangesAsync();

        return Created(
        $"/api/deliveries/{header.Id}",
        new
        {
            success = true,
            deliveryToken = header.DeliveryToken,
            message = "Delivery created"
        });
    }
}