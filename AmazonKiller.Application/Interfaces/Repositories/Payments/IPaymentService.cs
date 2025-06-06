namespace AmazonKiller.Application.Interfaces.Repositories.Payments;

public interface IPaymentService
{
    Task<string> CreatePaymentIntentAsync(decimal amount, string? paymentMethodId = null);
    // Возвращает clientSecret или результат Stripe

    Task<bool> ConfirmPaymentAsync(string paymentIntentId);
}