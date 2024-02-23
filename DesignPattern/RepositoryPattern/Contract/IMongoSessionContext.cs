using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Contract
{
    public interface IMongoSessionContext
    {
        IClientSessionHandle GetCurrentSession();
        void StartSession();
        void EndSession();
    }
}
