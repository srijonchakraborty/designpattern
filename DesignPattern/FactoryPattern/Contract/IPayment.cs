using Common.Model.Payment;

namespace FactoryPattern.Contract
{
    public interface IPayment
    {
        void ProcessPayment(PaymentData paymentData);
    }
}
