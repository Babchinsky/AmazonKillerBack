using AmazonKiller.Application.Features.Auth.Commands.ConfirmRegistration;
using AmazonKiller.Application.Features.Auth.Commands.Login;
using AmazonKiller.Application.Features.Auth.Commands.Refresh;
using AmazonKiller.Application.Features.Auth.Commands.RegisterAdmin;
using AmazonKiller.Application.Features.Auth.Commands.StartRegistration;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("register/start")]
    public async Task<IActionResult> Start([FromBody] StartRegistrationCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpPost("register/confirm")]
    public async Task<IActionResult> Confirm([FromBody] ConfirmRegistrationCommand cmd)
    {
        return Ok(await mediator.Send(cmd));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand cmd)
    {
        var result = await mediator.Send(cmd);
        return Ok(result);
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenCommand cmd)
    {
        return Ok(await mediator.Send(cmd));
    }

    [HttpPost("register/admin")]
    public async Task<IActionResult> RegisterAdmin([FromBody] RegisterAdminCommand command)
    {
        return Ok(await mediator.Send(command));
    }
}