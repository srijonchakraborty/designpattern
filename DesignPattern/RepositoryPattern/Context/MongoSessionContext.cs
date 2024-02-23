using MongoDB.Driver;
using RepositoryPattern.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Context
{
    public class MongoSessionContext : IMongoSessionContext
    {
        private readonly IMongoClient _client;
        private IClientSessionHandle _session;

        public MongoSessionContext(IMongoClient client)
        {
            _client = client;
        }

        public void StartSession()
        {
            _session = _client.StartSession();
        }

        public IClientSessionHandle GetCurrentSession()
        {
            return _session;
        }

        public void EndSession()
        {
            _session?.Dispose();
            _session = null;
        }
    }
}
