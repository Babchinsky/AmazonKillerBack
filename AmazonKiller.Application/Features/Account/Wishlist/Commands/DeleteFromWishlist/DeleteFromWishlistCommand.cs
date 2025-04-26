using MediatR;

namespace AmazonKiller.Application.Features.Account.Wishlist.Commands.DeleteFromWishlist;

public record DeleteFromWishlistCommand(Guid ProductId) : IRequest;