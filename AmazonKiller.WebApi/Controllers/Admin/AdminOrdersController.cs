using AmazonKiller.Application.Features.Orders.Admin.Commands.ChangeOrderStatus;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers.Admin;

[ApiController]
[Route("api/admin/orders")]
[Authorize(Roles = "Admin")]
public class AdminOrdersController(IMediator mediator) : ControllerBase
{
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