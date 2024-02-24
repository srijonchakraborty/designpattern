using FactoryPattern.Contract;

namespace FactoryPattern.FactoryMethodPattern.Contract
{
    public interface IPaymentFactory
    {
        IPayment CreatePayment();
    }
}
