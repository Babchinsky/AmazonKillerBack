using AmazonKiller.Application.Features.Auth.Commands.Login;
using AmazonKiller.Application.Features.Auth.Commands.Register;

namespace AmazonKiller.Application.Interfaces;

public interface IAuthService
{
    Task<string> RegisterAsync(RegisterUserCommand command);
    Task<string> LoginAsync(LoginUserCommand command);
}