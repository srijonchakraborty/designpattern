using Common.Model.Payment;
using FactoryPattern.Contract;

namespace FactoryPattern.Implementation
{
    public class BkashPayment : IPayment
    {
        public void ProcessPayment(PaymentData paymentData)
        {
            if (paymentData is BkashPaymentData)
            {
                var bkashPaymentData = paymentData as BkashPaymentData;
                if (bkashPaymentData != null)
                {
                    Console.WriteLine($"Processing Bkash Payment of {bkashPaymentData.Amount} taka from {bkashPaymentData.MobileNumber}");
                }
            }
            else
            {
                throw new ArgumentException("Invalid payment data for Bkash payment");
            }
        }
    }
}
