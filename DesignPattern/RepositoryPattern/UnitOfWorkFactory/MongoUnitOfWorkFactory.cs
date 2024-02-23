using MongoDB.Driver;
using RepositoryPattern.Contract;
using RepositoryPattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.UnitOfWorkFactory
{
    //public class MongoUnitOfWorkFactory : IUnitOfWorkFactory
    //{
    //    private readonly IMongoClient _client;

    //    public MongoUnitOfWorkFactory(IMongoClient client)
    //    {
    //        _client = client;
    //    }

    //    public IUnitOfWork Create()
    //    {
    //        var session = _client.StartSession();
    //        return new MongoDBUnitOfWork(session);
    //    }
    //}
    public class MongoUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IMongoSessionContext _sessionContext;
        private readonly IUnitOfWork _unitOfWork;

        public MongoUnitOfWorkFactory(IMongoSessionContext sessionContext,IUnitOfWork unitOfWork)
        {
            _sessionContext = sessionContext;
            _unitOfWork = unitOfWork;
        }

        public IUnitOfWork Create()
        {
            _sessionContext.StartSession();
            return _unitOfWork;
        }
    }
}
