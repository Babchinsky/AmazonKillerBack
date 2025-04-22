using AmazonKiller.Application.Features.Auth.Commands.Login;
using AmazonKiller.Application.Features.Auth.Commands.Refresh;
using AmazonKiller.Application.Features.Auth.Commands.Register;
using AmazonKiller.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService, IMediator mediator) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand cmd)
        => Ok(await mediator.Send(cmd));


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand cmd)
        => Ok(await authService.LoginAsync(cmd));

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenCommand cmd)
        => Ok(await mediator.Send(cmd));

    [HttpPost("register-admin")]
    public async Task<IActionResult> RegisterAdmin([FromBody] RegisterAdminCommand command)
        => Ok(await mediator.Send(command));
}