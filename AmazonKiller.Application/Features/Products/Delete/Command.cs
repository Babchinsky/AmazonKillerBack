using MediatR;

namespace AmazonKiller.Application.Features.Products.Delete;

public record DeleteProductCommand(Guid Id) : IRequest<bool>;