namespace RepositoryPattern.Contract
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
