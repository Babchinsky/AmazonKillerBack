using AmazonKiller.Application.Features.Account.Commands.ChangeEmail;
using AmazonKiller.Application.Features.Account.Commands.ChangeName;
using AmazonKiller.Application.Features.Account.Commands.ChangePassword;
using AmazonKiller.Application.Features.Account.Commands.DeleteAccount;
using AmazonKiller.Application.Features.Account.Commands.Logout;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AccountController(IMediator mediator) : ControllerBase
{
    [HttpPut("name")]
    public async Task<IActionResult> ChangeName([FromBody] ChangeNameCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpPut("email")]
    public async Task<IActionResult> ChangeEmail([FromBody] ChangeEmailCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpPut("password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await mediator.Send(new LogoutCommand());
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAccount()
    {
        await mediator.Send(new DeleteAccountCommand());
        return NoContent();
    }
}