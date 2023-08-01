using Common.Contracts.Order;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuilderPattern.BuilderInterface;
using Common.Model.Order;
using Common.DTOs.BuilderOption.Order;

namespace BuilderPattern.BuilderConcrete.OrderBuilder
{
    public class LCBuilder : OrderBuilder<ILC>
    {
        protected override ILC CreateInstance() => new LC();
        public OrderBuilder<ILC> SetBankName(string bankName)
        {
            target.BankName = bankName;
            return this;
        }
        public OrderBuilder<ILC> SetBankEmail(string bankEmail)
        {
            target.BankEmail = bankEmail;
            return this;
        }
    }
}
