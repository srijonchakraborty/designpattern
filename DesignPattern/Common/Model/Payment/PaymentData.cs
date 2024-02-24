using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Payment
{
    public class PaymentData
    {
        public decimal Amount { get; set; }
    }
    public class PayPalPaymentData : PaymentData
    {
        public string PayerEmail { get; set; }=string.Empty;
    }
    public class BkashPaymentData : PaymentData
    {
        public string MobileNumber { get; set; } = string.Empty;
    }
    public class CreditCardPaymentData : PaymentData
    {
        public string CardNumber { get; set; } = string.Empty;
        public string ExpiryDate { get; set; } = string.Empty;
        public string Cvv { get; set; } = string.Empty;
    }
}
