using Common.Model.Payment;

namespace FactoryPattern.SimpleFactory.Contract
{
    public interface IPayment
    {
        void ProcessPayment(PaymentData paymentData);
    }
}
