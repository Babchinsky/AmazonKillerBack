using AmazonKiller.Application.DTOs.Auth;
using AmazonKiller.Application.Interfaces;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.Register;

public class RegisterUserHandler(IAuthService authService)
    : IRequestHandler<RegisterUserCommand, AuthTokensDto>
{
    public Task<AuthTokensDto> Handle(RegisterUserCommand request, CancellationToken ct)
        => authService.RegisterAsync(request);
}