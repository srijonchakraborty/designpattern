using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Contract;
using RepositoryPattern.UnitOfWork;

namespace RepositoryPattern.Factory
{
    public class SqlServerUnitOfWorkFactory<T> : IUnitOfWorkFactory where T: DbContext
    {
        private readonly T _context;

        public SqlServerUnitOfWorkFactory(T context)
        {
            _context = context;
        }

        public IUnitOfWork Create()
        {
            return new SqlServerUnitOfWork<T>(_context);
        }
    }
}
