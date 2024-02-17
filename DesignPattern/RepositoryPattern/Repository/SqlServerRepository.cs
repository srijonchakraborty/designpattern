using System.Linq.Expressions;
using RepositoryPattern.Contract;
using Microsoft.EntityFrameworkCore;

namespace RepositoryPattern.Repository
{
    public class SqlServerRepository : IRepository
    {
        private readonly DbContext _dbContext;

        public SqlServerRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T?> GetByIdAsync<T>(string id) where T : class
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetByForeignIdAsync<T>(int foreignKeyId, string foreignKeyColumnName) where T : class
        {
            var parameterExpression = Expression.Parameter(typeof(T), "e");
            var memberExpression = Expression.PropertyOrField(parameterExpression, foreignKeyColumnName);
            var constantExpression = Expression.Constant(foreignKeyId, typeof(int));
            var equalExpression = Expression.Equal(memberExpression, constantExpression);
            var lambdaExpression = Expression.Lambda<Func<T, bool>>(equalExpression, parameterExpression);

            return await _dbContext.Set<T>().Where(lambdaExpression).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetByForeignIdAsync<T>(string foreignKeyId, string foreignKeyColumnName) where T : class
        {
            var parameterExpression = Expression.Parameter(typeof(T), "e");
            var memberExpression = Expression.PropertyOrField(parameterExpression, foreignKeyColumnName);
            var constantExpression = Expression.Constant(foreignKeyId, typeof(string));
            var equalExpression = Expression.Equal(memberExpression, constantExpression);
            var lambdaExpression = Expression.Lambda<Func<T, bool>>(equalExpression, parameterExpression);

            return await _dbContext.Set<T>().Where(lambdaExpression).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync<T>(T entity) where T : class
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }
        public IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return  _dbContext.Set<T>().Where(predicate).ToList();
        }

        public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            _dbContext.Set<T>().RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync<T>(T entity) where T : class
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
