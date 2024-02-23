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
    //public class MongoDBUnitOfWork : IUnitOfWork
    //{
    //    private readonly IClientSessionHandle _session;

    //    public IClientSessionHandle Session
    //    {
    //        get { return _session; }
    //    }


    //    public MongoDBUnitOfWork(IClientSessionHandle session)
    //    {
    //        _session = session;
    //    }
    //    public async Task<bool> SaveChangesAsync()
    //    {
    //        await _session.CommitTransactionAsync();
    //        return true;
    //    }
    //    public async Task<bool> ExecuteInTransactionAsync(Func<Task<bool>> transaction)
    //    {
    //        //try
    //        //{
    //        //    _session.StartTransaction();
    //        //    var result = await transaction();
    //        //    if (result)
    //        //    {
    //        //        await _session.CommitTransactionAsync();
    //        //        return true;
    //        //    }
    //        //}
    //        //catch (Exception)
    //        //{
    //        //    await _session.AbortTransactionAsync();
    //        //    throw;
    //        //}

    //        //return false;

    //        _session.StartTransaction(new TransactionOptions(
    //                readConcern: ReadConcern.Snapshot,
    //                writeConcern: WriteConcern.WMajority));

    //        try
    //        {
    //            var result = await transaction();
    //            // If an operation throws an exception, the transaction can be aborted
    //            // and the exception handled or re-thrown as needed.

    //            // Commit the transaction
    //            await _session.CommitTransactionAsync();
    //            return true;
    //        }
    //        catch (Exception ex)
    //        {
    //            // Abort the transaction on error
    //            await _session.AbortTransactionAsync();
    //            Console.WriteLine($"Transaction aborted due to an error: {ex.Message}");
    //            // Depending on your error handling strategy, you may want to re-throw the exception
    //            throw;
    //        }
    //    }

    //    public void Dispose()
    //    {
    //        GC.SuppressFinalize(this);
    //    }


    //}

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

            //try
            //{
            //    _session.StartTransaction();
            //    var result = await transaction();
            //    if (result)
            //    {
            //        await _session.CommitTransactionAsync();
            //        return true;
            //    }
            //}
            //catch (Exception)
            //{
            //    await _session.AbortTransactionAsync();
            //    throw;
            //}
            //finally
            //{
            //    _sessionContext.EndSession();
            //}
        }

        public void Dispose()
        {
            // Dispose resources if any
        }

        public async Task<bool> SaveChangesAsync()
        {
            await _sessionContext.GetCurrentSession().CommitTransactionAsync();
            return true;
        }
    }
}
