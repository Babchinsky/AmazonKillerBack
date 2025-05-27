using FluentValidation;

namespace AmazonKiller.Application.Features.Wishlist.Commands.AddToWishlist;

public class AddToWishlistValidator : AbstractValidator<AddToWishlistCommand>
{
    public AddToWishlistValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty();
    }
}