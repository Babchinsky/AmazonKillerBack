using AmazonKiller.Application.DTOs.Cart;
using AmazonKiller.Application.Features.Cart.Commands.AddProductToCart;
using AmazonKiller.Application.Features.Cart.Commands.RemoveProductFromCart;
using AmazonKiller.Application.Features.Cart.Commands.UpdateProductQuantityInCart;
using AmazonKiller.Application.Features.Cart.Queries.GetCart;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers.Account;

[ApiController]
[Route("api/account/cart")]
[Authorize]
public class CartController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<CartItemDto>>> Get(CancellationToken ct)
    {
        var result = await mediator.Send(new GetCartQuery(), ct);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<List<CartItemDto>>> Add([FromBody] AddProductToCartCommand cmd, CancellationToken ct)
    {
        var result = await mediator.Send(cmd, ct);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<List<CartItemDto>>> UpdateQuantity([FromBody] UpdateProductQuantityInCartCommand cmd,
        CancellationToken ct)
    {
        var result = await mediator.Send(cmd, ct);
        return Ok(result);
    }

    [HttpDelete("{productId:guid}")]
    public async Task<ActionResult<List<CartItemDto>>> Remove(Guid productId, CancellationToken ct)
    {
        var result = await mediator.Send(new RemoveProductFromCartCommand(productId), ct);
        return Ok(result);
    }
}