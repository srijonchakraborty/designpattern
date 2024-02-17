using System.Linq.Expressions;

namespace RepositoryPattern.Contract
{
    public interface IRepository
    {
        Task<T?> GetByIdAsync<T>(string id) where T : class;
        Task<IEnumerable<T>> GetByForeignIdAsync<T>(int foreignKeyId, string foreignKeyColumnName) where T : class;
        Task<IEnumerable<T>> GetByForeignIdAsync<T>(string foreignKeyId, string foreignKeyColumnName) where T : class;
        Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
        Task<T> AddAsync<T>(T entity) where T : class;
        Task<T> UpdateAsync<T>(T entity) where T : class;
        Task<T> DeleteAsync<T>(T entity) where T : class;
        Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
        IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task RemoveAsync<T>(T entity) where T : class;
        Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class;
        Task RemoveRangeAsync<T>(IEnumerable<T> entities) where T : class;
    }
}
