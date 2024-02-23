namespace RepositoryPattern.Contract
{
    public interface IUnitOfWork: IDisposable
    {
        Task<bool> SaveChangesAsync();
        Task<bool> ExecuteInTransactionAsync(Func<Task<bool>> transaction);
    }
}
