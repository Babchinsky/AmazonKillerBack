using MediatR;

namespace AmazonKiller.Application.Features.Wishlist.Commands.AddToWishlist;

public record AddToWishlistCommand(Guid ProductId) : IRequest;