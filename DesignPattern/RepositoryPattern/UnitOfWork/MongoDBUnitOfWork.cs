using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using RepositoryPattern.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace RepositoryPattern.UnitOfWork
{
    public class MongoDBUnitOfWork : IUnitOfWork
    {
        private readonly IMongoSessionContext _sessionContext;

        public MongoDBUnitOfWork(IMongoSessionContext sessionContext)
        {
            _sessionContext = sessionContext;
        }

        public async Task<bool> ExecuteInTransactionAsync(Func<Task<bool>> transaction)
        {
            try
            {
                var result = await transaction();
                if (result)
                {
                    await _sessionContext.GetCurrentSession().CommitTransactionAsync();
                    return true;
                }
                return result;
            }
            catch (Exception)
            {
                await _sessionContext.GetCurrentSession().AbortTransactionAsync();
                throw;
            }
            finally
            {
                _sessionContext.EndSession();
            }
        }

        public void Dispose()
        {
            
        }

        public async Task<bool> SaveChangesAsync()
        {
            await _sessionContext.GetCurrentSession().CommitTransactionAsync();
            return true;
        }
    }
}
