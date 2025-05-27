using MediatR;

namespace AmazonKiller.Application.Features.Wishlist.Commands.ToggleWishlist;

public record ToggleWishlistCommand(Guid ProductId) : IRequest;