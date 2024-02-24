using Common;
using FactoryPattern.SimpleFactory.Contract;
using FactoryPattern.SimpleFactory.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.SimpleFactory
{
    public class PaymentSimpleFactory
    {
        public IPayment CreatePayment(PaymentType type)
        {
            switch (type)
            {
                case PaymentType.CreditCard:
                    return new CreditCardPayment();
                case PaymentType.Paypal:
                    return new PayPalPayment();
                case PaymentType.Bkash:
                    return new BkashPayment();
                default:
                    throw new ArgumentException("Invalid payment type");
            }
        }
    }
}
