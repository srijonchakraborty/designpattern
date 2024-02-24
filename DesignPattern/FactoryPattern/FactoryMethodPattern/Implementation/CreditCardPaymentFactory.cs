using FactoryPattern.Contract;
using FactoryPattern.FactoryMethodPattern.Contract;
using FactoryPattern.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.FactoryMethodPattern.Implementation
{
    public class CreditCardPaymentFactory : IPaymentFactory
    {
        public IPayment CreatePayment()
        {
            var payment= new CreditCardPayment();
            payment.PaymentType = Common.PaymentType.CreditCard;
            //if CreditCardPayment class have other properties and logic you can set here
            return payment;
        }
    }
}
