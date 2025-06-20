﻿using AmazonKiller.Application.DTOs.Users;
using AmazonKiller.Application.Features.Profile.Commands.ChangeEmail.ConfirmEmailChange;
using AmazonKiller.Application.Features.Profile.Commands.ChangeEmail.ResendEmailChangeCode;
using AmazonKiller.Application.Features.Profile.Commands.ChangeEmail.StartEmailChange;
using AmazonKiller.Application.Features.Profile.Commands.ChangeName;
using AmazonKiller.Application.Features.Profile.Commands.ChangePassword;
using AmazonKiller.Application.Features.Profile.Commands.ChangePhoto;
using AmazonKiller.Application.Features.Profile.Commands.DeleteAccount;
using AmazonKiller.Application.Features.Profile.Commands.Logout;
using AmazonKiller.Application.Features.Users.Account.Queries.GetCurrentUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers.Account;

[ApiController]
[Route("api/account/profile")]
[Authorize]
public class ProfileController(IMediator mediator) : ControllerBase
{
    [HttpGet("me")]
    public async Task<ActionResult<UserInfoDto>> GetMe(CancellationToken ct)
    {
        var result = await mediator.Send(new GetCurrentUserQuery(), ct);
        return Ok(result);
    }

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

    [HttpPost("email-change/resend")]
    public async Task<IActionResult> ResendEmailChangeCode(CancellationToken ct)
    {
        await mediator.Send(new ResendEmailChangeCodeCommand(), ct);
        return NoContent();
    }

    [HttpPut("name")]
    public async Task<IActionResult> ChangeName([FromBody] ChangeNameCommand cmd, CancellationToken ct)
    {
        await mediator.Send(cmd, ct);
        return NoContent();
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
        return Ok(imageUrl);
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