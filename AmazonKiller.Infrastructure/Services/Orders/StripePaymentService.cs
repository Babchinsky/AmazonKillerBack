using AmazonKiller.Application.Interfaces.Repositories.Payments;
using AmazonKiller.Application.Options;
using Microsoft.Extensions.Options;
using Stripe;

namespace AmazonKiller.Infrastructure.Services.Orders;

public class StripePaymentService : IPaymentService
{
    public StripePaymentService(IOptions<StripeSettingsOptions> stripeOptions)
    {
        StripeConfiguration.ApiKey = stripeOptions.Value.SecretKey
                                     ?? throw new InvalidOperationException("Stripe secret key is not configured.");
    }

    public async Task<string> CreatePaymentIntentAsync(decimal amount, string? paymentMethodId)
    {
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
            },
        });

        return intent.Id; // или ClientSecret если фронту нужно
    }

    public async Task<bool> ConfirmPaymentAsync(string paymentIntentId)
    {
        var paymentIntentService = new PaymentIntentService();
        var intent = await paymentIntentService.ConfirmAsync(paymentIntentId);
        return intent.Status == "succeeded";
    }
}