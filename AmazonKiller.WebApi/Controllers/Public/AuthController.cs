using AmazonKiller.Application.Features.Auth.Commands.Login;
using AmazonKiller.Application.Features.Auth.Commands.Refresh;
using AmazonKiller.Application.Features.Auth.Commands.RegisterAdmin;
using AmazonKiller.Application.Features.Auth.Commands.Registration.CompleteRegistration;
using AmazonKiller.Application.Features.Auth.Commands.Registration.ConfirmRegistration;
using AmazonKiller.Application.Features.Auth.Commands.Registration.StartRegistration;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers.Public;

[ApiController]
[Route("api/auth")]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("register/start")]
    public async Task<IActionResult> Start([FromBody] StartRegistrationCommand cmd, CancellationToken ct)
    {
        await mediator.Send(cmd, ct);
        return NoContent();
    }

    [HttpPost("register/confirm")]
    public async Task<IActionResult> Confirm([FromBody] ConfirmRegistrationCommand cmd, CancellationToken ct)
    {
        await mediator.Send(cmd, ct);
        return NoContent();
    }

    [HttpPost("register/complete")]
    public async Task<IActionResult> Complete([FromBody] CompleteRegistrationCommand cmd, CancellationToken ct)
    {
        var result = await mediator.Send(cmd, ct);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand cmd, CancellationToken ct)
    {
        var result = await mediator.Send(cmd, ct);
        return Ok(result);
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenCommand cmd, CancellationToken ct)
    {
        return Ok(await mediator.Send(cmd, ct));
    }

    [HttpPost("register/admin")]
    public async Task<IActionResult> RegisterAdmin([FromBody] RegisterAdminCommand command, CancellationToken ct)
    {
        return Ok(await mediator.Send(command, ct));
    }
}