using MediatR;

namespace AmazonKiller.Application.Features.Account.Commands.DeleteFromWishlist;

public record DeleteFromWishlistCommand(Guid ProductId) : IRequest;