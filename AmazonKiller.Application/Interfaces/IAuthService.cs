using AmazonKiller.Application.Features.Auth.Commands.Login;
using AmazonKiller.Application.Features.Auth.Commands.Register;
using AmazonKiller.Domain.Entities.Users;

namespace AmazonKiller.Application.Interfaces;

public interface IAuthService
{
    Task<string> RegisterAsync(RegisterUserCommand command);
    Task<string> LoginAsync(LoginUserCommand command);
    Task<string> GenerateJwtTokenAsync(User user);
}