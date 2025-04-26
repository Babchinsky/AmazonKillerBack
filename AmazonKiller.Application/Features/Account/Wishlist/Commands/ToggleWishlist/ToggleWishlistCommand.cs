using MediatR;

namespace AmazonKiller.Application.Features.Account.Wishlist.Commands.ToggleWishlist;

public record ToggleWishlistCommand(Guid ProductId) : IRequest;