using Common.Model.Payment;
using FactoryPattern.SimpleFactory;
using Common;
using FactoryPattern.Contract;
using FactoryPattern.FactoryMethodPattern.Contract;
using FactoryPattern.FactoryMethodPattern.Implementation;

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

        internal static void FactoryMethodPatternImplementation()
        {
            CreditCardPaymentData ccPaymentData = PrepareCreditcardData();
            PayPalPaymentData paypalPaymentData = PreparePayPalData();
            BkashPaymentData bkashPaymentData = PrepareBkashData();

            //For CreditCard
            IPaymentFactory paymentFactory = new CreditCardPaymentFactory();
            IPayment payment = paymentFactory.CreatePayment();
            payment.ProcessPayment(ccPaymentData);

            //For PayPal
            paymentFactory = new PayPalPaymentFactory();
            payment = paymentFactory.CreatePayment();
            payment.ProcessPayment(paypalPaymentData);

            //For Bkash
            paymentFactory = new BkashPaymentFactory();
            payment = paymentFactory.CreatePayment();
            payment.ProcessPayment(bkashPaymentData);

            /**Here you can see that 
             * paymentFactory = new BkashPaymentFactory();
             * payment = paymentFactory.CreatePayment();
             * payment.ProcessPayment(bkashPaymentData);
             * These 3 lines are same for all different type of payment Where ever you need to add a new
             * Payment type. You Just need to implement the payment type and the Create a Factory that how 
             * the payment object will be create. Client class have no responsiblies rather than providing the 
             * payment related information
             **/
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
