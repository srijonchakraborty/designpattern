﻿using Common;
using Common.Model.Payment;
using FactoryPattern.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Implementation
{
    public class CreditCardPayment : IPayment
    {
        public PaymentType PaymentType { get; set; } 
        public void ProcessPayment(PaymentData paymentData)
        {
            if (paymentData is CreditCardPaymentData)
            {
                var ccData = paymentData as CreditCardPaymentData;
                if (ccData != null)
                {
                    Console.WriteLine($"Processing Credit Card Payment of {ccData.Amount:C} with card ending in " +
                                        $"{ccData.CardNumber.Substring(ccData.CardNumber.Length - 4)}");
                }
            }
            else
            {
                throw new ArgumentException("Invalid payment data for credit card payment");
            }
        }
    }
}
