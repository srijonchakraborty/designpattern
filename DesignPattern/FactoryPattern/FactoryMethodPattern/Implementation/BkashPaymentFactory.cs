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
    public class BkashPaymentFactory : IPaymentFactory
    {
        public IPayment CreatePayment()
        {
            var payment = new BkashPayment();
            payment.PaymentType = Common.PaymentType.Bkash;
            //if BkashPayment class have other properties and logic you can set here
            return payment;
        }
    }
}
