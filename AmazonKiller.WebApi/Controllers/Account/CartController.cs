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
    public async Task<IActionResult> Get(CancellationToken ct)
    {
        var result = await mediator.Send(new GetCartQuery(), ct);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddProductToCartCommand cmd, CancellationToken ct)
    {
        await mediator.Send(cmd, ct);
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateQuantity([FromBody] UpdateProductQuantityInCartCommand cmd,
        CancellationToken ct)
    {
        await mediator.Send(cmd, ct);
        return NoContent();
    }

    [HttpDelete("{productId:guid}")]
    public async Task<IActionResult> Remove(Guid productId, CancellationToken ct)
    {
        await mediator.Send(new RemoveProductFromCartCommand(productId), ct);
        return NoContent();
    }
}