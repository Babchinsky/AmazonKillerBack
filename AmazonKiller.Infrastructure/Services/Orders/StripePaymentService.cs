using AmazonKiller.Application.Interfaces.Repositories.Payments;
using AmazonKiller.Application.Options;
using AmazonKiller.Shared.Exceptions;
using Microsoft.Extensions.Options;
using Stripe;

namespace AmazonKiller.Infrastructure.Services.Orders;

public class StripePaymentService : IPaymentService
{
    private readonly bool _enabled;

    public StripePaymentService(IOptions<StripeSettingsOptions> stripeOptions)
    {
        var opts = stripeOptions.Value;
        _enabled = opts.UseStripe;

        if (_enabled)
            StripeConfiguration.ApiKey = !string.IsNullOrWhiteSpace(opts.SecretKey)
                ? opts.SecretKey
                : throw new AppException("Stripe is enabled but SecretKey is missing.");
    }

    public async Task<string> CreatePaymentIntentAsync(decimal amount, string? paymentMethodId)
    {
        if (!_enabled)
            return string.Empty; // or return null if caller allows it

        var paymentIntentService = new PaymentIntentService();
        var intent = await paymentIntentService.CreateAsync(new PaymentIntentCreateOptions
        {
            Amount = (long)(amount * 100),
            Currency = "usd",
            PaymentMethod = paymentMethodId,
            // ConfirmationMethod = "manual",
            //Confirm = true,
            AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
            {
                Enabled = true,
                AllowRedirects = "never"
            }
        });

        return intent.Id; // или ClientSecret если фронту нужно
    }

    public async Task<bool> ConfirmPaymentAsync(string paymentIntentId)
    {
        if (!_enabled)
            return true; // Assume success if Stripe is off

        var paymentIntentService = new PaymentIntentService();
        var intent = await paymentIntentService.ConfirmAsync(paymentIntentId);
        return intent.Status == "succeeded";
    }
}