using Common.Model.Payment;
using FactoryPattern.SimpleFactory;
using Common;
using FactoryPattern.Contract;

namespace DesignPattern
{
    internal static class FactoryPatternImplementation
    {
        internal static void SimpleFactoryPatternImplementation()
        {
            PaymentSimpleFactory factory = new PaymentSimpleFactory();

            CreditCardPaymentData ccPaymentData = PrepareCreditcardData();
            PayPalPaymentData paypalPaymentData = PreparePayPalData();
            BkashPaymentData bkashPaymentData = PrepareBkashData();

            IPayment creditCardPayment = factory.CreatePayment(PaymentType.CreditCard);
            creditCardPayment.ProcessPayment(ccPaymentData);

            IPayment payPalPayment = factory.CreatePayment(PaymentType.Paypal);
            payPalPayment.ProcessPayment(paypalPaymentData);

            IPayment bkashPayment = factory.CreatePayment(PaymentType.Bkash);
            bkashPayment.ProcessPayment(bkashPaymentData);
        }

        private static PayPalPaymentData PreparePayPalData()
        {
            PayPalPaymentData paypalPaymentData = new PayPalPaymentData();
            paypalPaymentData.Amount = 50.00m;
            paypalPaymentData.PayerEmail = "srijon@yopmail.com";
            return paypalPaymentData;
        }
        private static BkashPaymentData PrepareBkashData()
        {
            BkashPaymentData bkashPaymentData = new BkashPaymentData();
            bkashPaymentData.Amount = 50;
            bkashPaymentData.MobileNumber = "+8801552111111";
            return bkashPaymentData;
        }

        private static CreditCardPaymentData PrepareCreditcardData()
        {
            CreditCardPaymentData ccPaymentData = new CreditCardPaymentData();
            ccPaymentData.Amount = 100.00m;
            ccPaymentData.CardNumber = "1234567890123456";
            ccPaymentData.ExpiryDate = "12/25";
            ccPaymentData.Cvv = "444";
            return ccPaymentData;
        }
    }
}
