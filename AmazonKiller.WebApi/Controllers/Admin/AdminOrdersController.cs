using AmazonKiller.Application.Features.Orders.Admin.Commands.ChangeOrderStatus;
using AmazonKiller.Application.Features.Orders.Admin.Queries.GetAdminOrderDetails;
using AmazonKiller.Application.Features.Orders.Admin.Queries.GetAllOrders;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers.Admin;

[ApiController]
[Route("api/admin/orders")]
[Authorize(Roles = "Admin")]
public class AdminOrdersController(IMediator mediator) : ControllerBase
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
        var result = await mediator.Send(new GetAdminOrderDetailsQuery(id), ct);
        return Ok(result);
    }

    [HttpPut("{id:guid}/status")]
    public async Task<IActionResult> ChangeStatus(Guid id, [FromBody] ChangeOrderStatusCommand cmd,
        CancellationToken ct)
    {
        if (id != cmd.OrderId)
            return BadRequest("Mismatched OrderId");

        await mediator.Send(cmd, ct);
        return NoContent();
    }
}