using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.Login;

public record LoginUserCommand(string Email, string Password) : IRequest<string>; // returns token