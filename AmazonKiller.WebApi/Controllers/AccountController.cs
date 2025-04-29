using AmazonKiller.Application.Features.Account.Orders.Commands.AddProductToOrder;
using AmazonKiller.Application.Features.Account.Orders.Commands.CreateOrder;
using AmazonKiller.Application.Features.Account.Orders.Commands.RemoveProductFromOrder;
using AmazonKiller.Application.Features.Account.Orders.Queries.GetOrderDetails;
using AmazonKiller.Application.Features.Account.Orders.Queries.GetOrders;
using AmazonKiller.Application.Features.Account.Profile.Commands.ChangeEmail.ConfirmEmailChange;
using AmazonKiller.Application.Features.Account.Profile.Commands.ChangeEmail.StartEmailChange;
using AmazonKiller.Application.Features.Account.Profile.Commands.ChangeName;
using AmazonKiller.Application.Features.Account.Profile.Commands.ChangePassword;
using AmazonKiller.Application.Features.Account.Profile.Commands.DeleteAccount;
using AmazonKiller.Application.Features.Account.Profile.Commands.Logout;
using AmazonKiller.Application.Features.Account.Wishlist.Commands.AddToWishlist;
using AmazonKiller.Application.Features.Account.Wishlist.Commands.DeleteFromWishlist;
using AmazonKiller.Application.Features.Account.Wishlist.Commands.ToggleWishlist;
using AmazonKiller.Application.Features.Account.Wishlist.Queries.GetWishlist;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AccountController(IMediator mediator) : ControllerBase
{
    [HttpPost("email-change/start")]
    public async Task<IActionResult> StartEmailChange([FromBody] StartEmailChangeCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpPost("email-change/confirm")]
    public async Task<IActionResult> ConfirmEmailChange([FromBody] ConfirmEmailChangeCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpPut("name")]
    public async Task<IActionResult> ChangeName([FromBody] ChangeNameCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpPut("password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await mediator.Send(new LogoutCommand());
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAccount()
    {
        await mediator.Send(new DeleteAccountCommand());
        return NoContent();
    }

    [HttpGet("wishlist")]
    [Tags("Wishlist")]
    public async Task<IActionResult> GetWishlist()
    {
        var result = await mediator.Send(new GetWishlistQuery());
        return Ok(result);
    }

    [Authorize]
    [HttpPost("wishlist/toggle")]
    [Tags("Wishlist")]
    public async Task<IActionResult> ToggleWishlist([FromBody] ToggleWishlistCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpPost("wishlist")]
    [Tags("Wishlist")]
    public async Task<IActionResult> AddToWishlist([FromBody] AddToWishlistCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpDelete("wishlist/{productId:guid}")]
    [Tags("Wishlist")]
    public async Task<IActionResult> DeleteFromWishlist(Guid productId)
    {
        await mediator.Send(new DeleteFromWishlistCommand(productId));
        return NoContent();
    }

    [Authorize]
    [HttpGet("orders")]
    [Tags("Orders")]
    public async Task<IActionResult> GetOrders()
    {
        var orders = await mediator.Send(new GetOrdersQuery());
        return Ok(orders);
    }

    [Authorize]
    [HttpGet("orders/{id:guid}")]
    [Tags("Orders")]
    public async Task<IActionResult> GetOrderDetails(Guid id)
    {
        var details = await mediator.Send(new GetOrderDetailsQuery(id));
        return Ok(details);
    }

    [HttpPost("orders")]
    [Tags("Orders")]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
    {
        var id = await mediator.Send(command);
        return Ok(id);
    }

    [HttpPost("orders/products")]
    [Tags("Orders")]
    public async Task<IActionResult> AddProductToOrder([FromBody] AddProductToOrderCommand cmd, CancellationToken ct)
    {
        await mediator.Send(cmd, ct);
        return NoContent();
    }

    [HttpDelete("{orderId:guid}/products/{productId:guid}")]
    [Tags("Orders")]
    public async Task<IActionResult> RemoveProductFromOrder(Guid orderId, Guid productId, CancellationToken ct)
    {
        await mediator.Send(new RemoveProductFromOrderCommand(orderId, productId), ct);
        return NoContent();
    }
}