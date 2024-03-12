using System;

interface IPaymentService
{
    Payment ProcessPayment(User user, Subscription subscription, string paymentMethod);
}

class PaymentService : IPaymentService
{
    public Payment ProcessPayment(User user, Subscription subscription, string paymentMethod)
    {
        // Mock data for a successful payment
        return new Payment
        {
            PaymentId = new Random().Next(1000, 9999),
            PaymentMethod = paymentMethod,
            UserId = user.UserId,
            Date = DateTime.Now,
        };
    }
}
