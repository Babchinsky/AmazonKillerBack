using MediatR;

namespace AmazonKiller.Application.Features.Products.Commands.Delete;

public record DeleteProductCommand(Guid Id) : IRequest<bool>;