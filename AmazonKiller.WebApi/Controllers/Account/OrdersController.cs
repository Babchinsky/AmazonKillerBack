using AmazonKiller.Application.Features.Orders.Public.Commands.CreateOrder;
using AmazonKiller.Application.Features.Orders.Public.Queries.GetAllOrders;
using AmazonKiller.Application.Features.Orders.Public.Queries.GetOrderDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers.Account;

[ApiController]
[Route("api/account/orders")]
[Authorize]
public class OrdersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllOrdersQuery q, CancellationToken ct)
    {
        var list = await mediator.Send(q, ct);
        return Ok(list);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var details = await mediator.Send(new GetOrderDetailsQuery(id), ct);
        return Ok(details);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderCommand command, CancellationToken ct)
    {
        var id = await mediator.Send(command, ct);
        return Ok(id);
    }
}