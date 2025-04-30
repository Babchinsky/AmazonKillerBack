using AmazonKiller.Application.Features.Auth.Commands.ConfirmRegistration;
using AmazonKiller.Application.Features.Auth.Commands.Login;
using AmazonKiller.Application.Features.Auth.Commands.Refresh;
using AmazonKiller.Application.Features.Auth.Commands.RegisterAdmin;
using AmazonKiller.Application.Features.Auth.Commands.StartRegistration;
using AmazonKiller.Application.Interfaces;
using AmazonKiller.Application.Interfaces.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService, IMediator mediator) : ControllerBase
{
    [HttpPost("start-registration")]
    public async Task<IActionResult> Start([FromBody] StartRegistrationCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpPost("confirm-registration")]
    public async Task<IActionResult> Confirm(ConfirmRegistrationCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand cmd)
    {
        return Ok(await authService.LoginAsync(cmd));
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenCommand cmd)
    {
        return Ok(await mediator.Send(cmd));
    }

    [HttpPost("register-admin")]
    public async Task<IActionResult> RegisterAdmin([FromBody] RegisterAdminCommand command)
    {
        return Ok(await mediator.Send(command));
    }
}