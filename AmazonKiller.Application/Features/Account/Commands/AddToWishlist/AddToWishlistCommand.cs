using MediatR;

namespace AmazonKiller.Application.Features.Account.Commands.AddToWishlist;

public record AddToWishlistCommand(Guid ProductId) : IRequest;