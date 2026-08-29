namespace PaymentGateway
{
    public class CheckoutService
    {
        private readonly IPaymentGateway _paymentGateway;

        public CheckoutService(IPaymentGateway paymentGateway)
        {
            _paymentGateway = paymentGateway;
        }

        public PaymentResult Checkout(decimal amount)
        {
            return _paymentGateway.Pay(amount);
        }
    }
}
