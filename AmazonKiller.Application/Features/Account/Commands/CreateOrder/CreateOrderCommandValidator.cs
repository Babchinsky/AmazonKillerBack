using AmazonKiller.Domain.Entities.Orders;
using FluentValidation;

namespace AmazonKiller.Application.Features.Account.Commands.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        When(x => x.PaymentType == PaymentType.Card, () =>
        {
            RuleFor(x => x.CardNumber)
                .NotEmpty().WithMessage("Card number is required.")
                .CreditCard().WithMessage("Invalid card number.");

            RuleFor(x => x.ExpirationDate)
                .NotEmpty().WithMessage("Expiration date is required.")
                .Matches(@"^\d{2}/\d{2,4}$").WithMessage("ExpirationDate must be in MM/YY or MM/YYYY format.");

            RuleFor(x => x.Cvv)
                .NotEmpty().WithMessage("CVV is required.")
                .Matches(@"^\d{3,4}$").WithMessage("CVV must be 3 or 4 digits.");
        });
    }
}