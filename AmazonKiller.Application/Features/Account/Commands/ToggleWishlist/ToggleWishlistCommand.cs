using MediatR;

namespace AmazonKiller.Application.Features.Account.Commands.ToggleWishlist;

public record ToggleWishlistCommand(Guid ProductId) : IRequest;