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
public class AdminUsersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllUsersQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPut("{userId:guid}/role/promote")]
    public async Task<IActionResult> PromoteToAdmin(Guid userId)
    {
        await mediator.Send(new MakeUserAdminCommand(userId));
        return NoContent();
    }

    [HttpPut("{userId:guid}/role/demote")]
    public async Task<IActionResult> DemoteFromAdmin(Guid userId)
    {
        await mediator.Send(new DemoteAdminCommand(userId));
        return NoContent();
    }

    [HttpDelete("delete-many")]
    public async Task<IActionResult> BulkDelete([FromBody] BulkDeleteUsersCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpPatch("restore-many")]
    public async Task<IActionResult> BulkRestore([FromBody] BulkRestoreUsersCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpGet("{userId:guid}/orders")]
    public async Task<IActionResult> GetUserOrders(Guid userId)
    {
        var result = await mediator.Send(new GetUserOrdersAdminQuery(userId));
        return Ok(result);
    }

    [HttpGet("{userId:guid}/reviews")]
    public async Task<IActionResult> GetUserReviews(Guid userId)
    {
        var result = await mediator.Send(new GetUserReviewsAdminQuery(userId));
        return Ok(result);
    }
}