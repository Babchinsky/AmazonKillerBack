using AmazonKiller.Application.Features.Account.Profile.Commands.ChangeEmail.ConfirmEmailChange;
using AmazonKiller.Application.Features.Account.Profile.Commands.ChangeEmail.StartEmailChange;
using AmazonKiller.Application.Features.Account.Profile.Commands.ChangeName;
using AmazonKiller.Application.Features.Account.Profile.Commands.ChangePassword;
using AmazonKiller.Application.Features.Account.Profile.Commands.DeleteAccount;
using AmazonKiller.Application.Features.Account.Profile.Commands.Logout;
using AmazonKiller.Shared.Exceptions;
using AmazonKiller.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers.Account;

[ApiController]
[Route("api/profile")]
[Authorize]
public class ProfileController(IMediator mediator) : ControllerBase
{
    [HttpPost("email-change/start")]
    public async Task<IActionResult> StartEmailChange([FromBody] StartEmailChangeCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpPost("email-change/confirm")]
    public async Task<IActionResult> ConfirmEmailChange([FromBody] ConfirmEmailChangeCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpPut("name")]
    public async Task<IActionResult> ChangeName([FromBody] ChangeNameCommand cmd)
    {
        try
        {
            await mediator.Send(cmd);
            return NoContent();
        }
        catch (AppException ex) when (ex.Message == "New name cannot be the same as the current name")
        {
            return Problem(ex.Message);
        }
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