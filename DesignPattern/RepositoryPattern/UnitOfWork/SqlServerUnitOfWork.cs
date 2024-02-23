using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Contract;

namespace RepositoryPattern.UnitOfWork
{
    public class SqlServerUnitOfWork<T> : IUnitOfWork where T : DbContext
    {
        private readonly T _context;
        private bool _disposed = false;
        public SqlServerUnitOfWork(T context)
        {
            _context = context;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ExecuteInTransactionAsync(Func<Task<bool>> transactionAsync)
        {
            IDbContextTransaction tContext = null;
            try
            {
                await using var transactionContext = await _context.Database.BeginTransactionAsync();
                tContext = transactionContext;
                var result = await transactionAsync();
                if (result)
                {
                    await tContext.CommitAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                await tContext?.RollbackAsync();
            }

            return false;
        }

        public void Dispose()
        {
            //Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
