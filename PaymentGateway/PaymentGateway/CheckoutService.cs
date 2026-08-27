namespace PaymentGateway
{
    public class CheckoutService
    {
        PaymentGatewayInterface _paymentGatewayInterface;
        CheckoutService(PaymentGatewayInterface paymentGatewayInterface)
        {
            this._paymentGatewayInterface = paymentGatewayInterface;
        }
        public void Checkout(int id, int amount)
        {
            _paymentGatewayInterface.Pay(id, amount);
        }
    }
}
