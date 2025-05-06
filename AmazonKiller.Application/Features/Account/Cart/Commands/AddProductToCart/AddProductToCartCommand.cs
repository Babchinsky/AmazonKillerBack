using MediatR;

namespace AmazonKiller.Application.Features.Account.Cart.Commands.AddProductToCart;

public record AddProductToCartCommand(Guid ProductId, int Quantity) : IRequest;