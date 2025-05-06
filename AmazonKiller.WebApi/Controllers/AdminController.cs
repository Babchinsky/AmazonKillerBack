using AmazonKiller.Application.Features.Admin.Users.Commands.BulkDeleteUsers;
using AmazonKiller.Application.Features.Admin.Users.Commands.BulkRestoreUsers;
using AmazonKiller.Application.Features.Admin.Users.Commands.DemoteAdmin;
using AmazonKiller.Application.Features.Admin.Users.Commands.MakeUserAdmin;
using AmazonKiller.Application.Features.Admin.Users.Queries.GetAllUsers;
using AmazonKiller.Application.Features.Admin.Users.Queries.GetUserOrdersAdmin;
using AmazonKiller.Application.Features.Admin.Users.Queries.GetUserReviewsAdmin;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers;

[ApiController]
[Route("api/admin/users")]
[Authorize(Roles = "Admin")]
public class AdminController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllUsersQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPut("{userId:guid}/make-admin")]
    public async Task<IActionResult> MakeAdmin(Guid userId)
    {
        await mediator.Send(new MakeUserAdminCommand(userId));
        return NoContent();
    }

    [HttpPut("{userId:guid}/demote-admin")]
    public async Task<IActionResult> MakeUser(Guid userId)
    {
        await mediator.Send(new DemoteAdminCommand(userId));
        return NoContent();
    }

    [HttpPatch("delete")]
    public async Task<IActionResult> DeleteUsers([FromBody] BulkDeleteUsersCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpPatch("restore")]
    public async Task<IActionResult> RestoreUsers([FromBody] BulkRestoreUsersCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpGet("{userId:guid}/orders")]
    public async Task<IActionResult> GetOrders(Guid userId)
    {
        var result = await mediator.Send(new GetUserOrdersAdminQuery(userId));
        return Ok(result);
    }

    [HttpGet("{userId:guid}/reviews")]
    public async Task<IActionResult> GetReviews(Guid userId)
    {
        var result = await mediator.Send(new GetUserReviewsAdminQuery(userId));
        return Ok(result);
    }
}