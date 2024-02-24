using Common;
using Common.Model.Payment;

namespace FactoryPattern.Contract
{
    public interface IPayment
    {
        PaymentType PaymentType { get; set; }
        void ProcessPayment(PaymentData paymentData);
    }
}
