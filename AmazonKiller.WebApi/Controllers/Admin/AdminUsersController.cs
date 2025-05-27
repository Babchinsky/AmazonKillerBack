using AmazonKiller.Application.Features.Users.Commands.BulkDeleteUsers;
using AmazonKiller.Application.Features.Users.Commands.BulkRestoreUsers;
using AmazonKiller.Application.Features.Users.Commands.DemoteAdmin;
using AmazonKiller.Application.Features.Users.Commands.MakeUserAdmin;
using AmazonKiller.Application.Features.Users.Queries.GetAllUsers;
using AmazonKiller.Application.Features.Users.Queries.GetUserOrdersAdmin;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers.Admin;

[ApiController]
[Route("api/admin/users")]
[Authorize(Roles = "Admin")]
public class AdminUsersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllUsersQuery query, CancellationToken ct)
    {
        var result = await mediator.Send(query, ct);
        return Ok(result);
    }

    [HttpPut("{userId:guid}/role/promote")]
    public async Task<IActionResult> PromoteToAdmin(Guid userId, CancellationToken ct)
    {
        await mediator.Send(new MakeUserAdminCommand(userId), ct);
        return NoContent();
    }

    [HttpPut("{userId:guid}/role/demote")]
    public async Task<IActionResult> DemoteFromAdmin(Guid userId, CancellationToken ct)
    {
        await mediator.Send(new DemoteAdminCommand(userId), ct);
        return NoContent();
    }

    [HttpDelete("delete-many")]
    public async Task<IActionResult> BulkDelete([FromBody] BulkDeleteUsersCommand cmd, CancellationToken ct)
    {
        var result = await mediator.Send(cmd, ct);
        return Ok(result);
    }

    [HttpPatch("restore-many")]
    public async Task<IActionResult> BulkRestore([FromBody] BulkRestoreUsersCommand cmd, CancellationToken ct)
    {
        var result = await mediator.Send(cmd, ct);
        return Ok(result);
    }

    [HttpGet("{userId:guid}/orders")]
    public async Task<IActionResult> GetUserOrders(Guid userId, CancellationToken ct)
    {
        var result = await mediator.Send(new GetUserOrdersAdminQuery(userId), ct);
        return Ok(result);
    }
}