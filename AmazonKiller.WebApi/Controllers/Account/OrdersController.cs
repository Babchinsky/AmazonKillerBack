using AmazonKiller.Application.Features.Orders.Account.Commands.CreateOrder;
using AmazonKiller.Application.Features.Orders.Account.Queries.GetUserOrderDetails;
using AmazonKiller.Application.Features.Orders.Account.Queries.GetUserOrders;
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
    public async Task<IActionResult> GetAll([FromQuery] GetUserOrdersQuery q, CancellationToken ct)
    {
        var list = await mediator.Send(q, ct);
        return Ok(list);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var details = await mediator.Send(new GetUserOrderDetailsQuery(id), ct);
        return Ok(details);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderCommand command, CancellationToken ct)
    {
        var id = await mediator.Send(command, ct);
        return Ok(id);
    }
}