using System.Linq.Expressions;

namespace RepositoryPattern.Contract
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetByForeignIdAsync(int foreignKeyId, string foreignKeyColumnName);
        Task<IEnumerable<T>> GetByForeignIdAsync(string foreignKeyId, string foreignKeyColumnName);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task RemoveAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task RemoveRangeAsync(IEnumerable<T> entities);
    }
}
