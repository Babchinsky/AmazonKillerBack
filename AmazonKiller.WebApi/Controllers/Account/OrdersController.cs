using AmazonKiller.Application.Features.Account.Orders.Commands.ChangeOrderStatus;
using AmazonKiller.Application.Features.Account.Orders.Commands.CreateOrder;
using AmazonKiller.Application.Features.Account.Orders.Queries.GetAllOrders;
using AmazonKiller.Application.Features.Account.Orders.Queries.GetOrderDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers.Account;

[ApiController]
[Route("api/orders")]
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
    public async Task<IActionResult> GetById(Guid id)
    {
        var details = await mediator.Send(new GetOrderDetailsQuery(id));
        return Ok(details);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
    {
        var id = await mediator.Send(command);
        return Ok(id);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id:guid}/status")]
    public async Task<IActionResult> ChangeStatus(Guid id, [FromBody] ChangeOrderStatusCommand cmd)
    {
        if (id != cmd.OrderId)
            return BadRequest("Mismatched OrderId");

        await mediator.Send(cmd);
        return NoContent();
    }
}