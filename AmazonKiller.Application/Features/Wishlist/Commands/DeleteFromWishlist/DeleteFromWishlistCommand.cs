using MediatR;

namespace AmazonKiller.Application.Features.Wishlist.Commands.DeleteFromWishlist;

public record DeleteFromWishlistCommand(Guid ProductId) : IRequest;