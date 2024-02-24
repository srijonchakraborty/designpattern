using Common;
using Common.Model.Payment;
using FactoryPattern.Contract;

namespace FactoryPattern.Implementation
{
    public class PayPalPayment : IPayment
    {
        public PaymentType PaymentType { get; set; }
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
