using Common.Model.Payment;
using FactoryPattern.SimpleFactory.Contract;

namespace FactoryPattern.SimpleFactory.Implementation
{
    public class PayPalPayment : IPayment
    {
        public void ProcessPayment(PaymentData paymentData)
        {
            if (paymentData is PayPalPaymentData)
            {
                var paypalData = paymentData as PayPalPaymentData;
                if (paypalData != null)
                {
                    Console.WriteLine($"Processing PayPal Payment of {paypalData.Amount:C} from {paypalData.PayerEmail}");
                }
            }
            else
            {
                throw new ArgumentException("Invalid payment data for PayPal payment");
            }
        }
    }
}
