using AmazonKiller.Application.DTOs.Users;
using AmazonKiller.Application.Features.Users.Account.Queries.GetCurrentUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers.Account;

[ApiController]
[Route("api/account/users")]
[Authorize]
public class AccountUsersController(IMediator mediator) : ControllerBase
{
    [HttpGet("me")]
    public async Task<ActionResult<UserInfoDto>> GetMe(CancellationToken ct)
    {
        var result = await mediator.Send(new GetCurrentUserQuery(), ct);
        return Ok(result);
    }
}