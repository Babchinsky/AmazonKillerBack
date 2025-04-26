using MediatR;

namespace AmazonKiller.Application.Features.Account.Wishlist.Commands.AddToWishlist;

public record AddToWishlistCommand(Guid ProductId) : IRequest;