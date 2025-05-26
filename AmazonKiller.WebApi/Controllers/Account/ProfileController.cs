using AmazonKiller.Application.Features.Account.Profile.Commands.ChangeEmail.ConfirmEmailChange;
using AmazonKiller.Application.Features.Account.Profile.Commands.ChangeEmail.StartEmailChange;
using AmazonKiller.Application.Features.Account.Profile.Commands.ChangeName;
using AmazonKiller.Application.Features.Account.Profile.Commands.ChangePassword;
using AmazonKiller.Application.Features.Account.Profile.Commands.ChangePhoto;
using AmazonKiller.Application.Features.Account.Profile.Commands.DeleteAccount;
using AmazonKiller.Application.Features.Account.Profile.Commands.Logout;
using AmazonKiller.Shared.Exceptions;
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
    public async Task<IActionResult> StartEmailChange([FromBody] StartEmailChangeCommand cmd, CancellationToken ct)
    {
        await mediator.Send(cmd, ct);
        return NoContent();
    }

    [HttpPost("email-change/confirm")]
    public async Task<IActionResult> ConfirmEmailChange([FromBody] ConfirmEmailChangeCommand cmd, CancellationToken ct)
    {
        await mediator.Send(cmd, ct);
        return NoContent();
    }

    [HttpPut("name")]
    public async Task<IActionResult> ChangeName([FromBody] ChangeNameCommand cmd, CancellationToken ct)
    {
        try
        {
            await mediator.Send(cmd, ct);
            return NoContent();
        }
        catch (AppException ex) when (ex.Message == "New name cannot be the same as the current name")
        {
            return Problem(ex.Message);
        }
    }

    [HttpPut("password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand cmd, CancellationToken ct)
    {
        await mediator.Send(cmd, ct);
        return NoContent();
    }

    [HttpPut("photo")]
    public async Task<ActionResult<string>> ChangePhoto([FromForm] ChangePhotoCommand cmd, CancellationToken ct)
    {
        var imageUrl = await mediator.Send(cmd, ct);
        return Ok($"{Request.Scheme}://{Request.Host}/uploads/{imageUrl}");
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout(CancellationToken ct)
    {
        await mediator.Send(new LogoutCommand(), ct);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAccount(CancellationToken ct)
    {
        await mediator.Send(new DeleteAccountCommand(), ct);
        return NoContent();
    }
}