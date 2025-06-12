using AmazonKiller.Application.Validators.Common;
using FluentValidation;
using AmazonKiller.Domain.Entities.Orders;

namespace AmazonKiller.Application.Features.Orders.Account.Commands.CreateOrder;

public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderValidator()
    {
        // Получатель
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .FirstName();

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .LastName();

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .ValidEmail();

        // Address
        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Country is required.");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required.");

        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("Street is required.");

        RuleFor(x => x.HouseNumber)
            .NotEmpty().WithMessage("House number is required.");

        RuleFor(x => x.PostCode)
            .NotEmpty().WithMessage("Post code is required.");

        // Пример: если страна — США, штат обязателен и почтовый код должен быть формата ZIP
        When(x => x.Country.Equals("united states", StringComparison.CurrentCultureIgnoreCase), () =>
        {
            RuleFor(x => x.State)
                .NotEmpty().WithMessage("State is required for US.");

            RuleFor(x => x.PostCode)
                .Matches(@"^\d{5}(-\d{4})?$").WithMessage("Invalid US ZIP code.");
        });

        // Платёжная информация (только если оплата картой)
        When(x => x.PaymentType == PaymentType.Card, () =>
        {
            RuleFor(x => x.CardNumber)
                .NotEmpty().WithMessage("Card number is required.")
                .CreditCard().WithMessage("Invalid card number.");

            RuleFor(x => x.ExpirationDate)
                .NotEmpty().WithMessage("Expiration date is required.")
                .Matches(@"^\d{2}/\d{2,4}$").WithMessage("Expiration date must be MM/YY or MM/YYYY.");

            RuleFor(x => x.Cvv)
                .NotEmpty().WithMessage("CVV is required.")
                .Matches(@"^\d{3,4}$").WithMessage("CVV must be 3 or 4 digits.");
        });
    }
}