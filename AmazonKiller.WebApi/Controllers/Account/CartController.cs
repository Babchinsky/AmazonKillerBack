using AmazonKiller.Application.Features.Account.Cart.Commands.AddProductToCart;
using AmazonKiller.Application.Features.Account.Cart.Commands.RemoveProductFromCart;
using AmazonKiller.Application.Features.Account.Cart.Commands.UpdateProductQuantityInCart;
using AmazonKiller.Application.Features.Account.Cart.Queries.GetCart;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers.Account;

[ApiController]
[Route("api/account/cart")]
[Authorize]
public class CartController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddProductToCartCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateQuantity([FromBody] UpdateProductQuantityInCartCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpDelete("{productId:guid}")]
    public async Task<IActionResult> Remove(Guid productId)
    {
        await mediator.Send(new RemoveProductFromCartCommand(productId));
        return NoContent();
    }

    [HttpGet("cart")]
    public async Task<IActionResult> GetCart()
    {
        var result = await mediator.Send(new GetCartQuery());
        return Ok(result);
    }
}