using MediatR;

namespace AmazonKiller.Application.Features.Profile.Commands.ChangeEmail.ResendEmailChangeCode;

public record ResendEmailChangeCodeCommand : IRequest;