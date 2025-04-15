using AmazonKiller.Application.Features.Auth.Commands.Login;
using AmazonKiller.Application.Features.Auth.Commands.Register;
using AmazonKiller.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        => Ok(await authService.RegisterAsync(command));

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        => Ok(await authService.LoginAsync(command));
}