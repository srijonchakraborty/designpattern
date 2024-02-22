using Common.Model;
using Common.Model.Order;
using DesignPattern.DBContext.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
//using Repository.Models;
using RepositoryPattern.Contract;
using RepositoryPattern.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{


    public class RepositoryPatternImplementation
    {
        private readonly IRepository _repository;
        public RepositoryPatternImplementation(IRepository repository) 
        {
            _repository = repository;
        }
        public async Task<T> Save<T>(T obj) where T : class
        {
            return await _repository.AddAsync(obj);
        }
        public async Task<SystemNotification> GetNotification(string id)
        {
            
#if SQLSERVER
            SystemNotification systemNotification = _repository.FindAsync<SystemNotification>(c => c.NotificationId == int.Parse(id)).Result?.FirstOrDefault();
#elif MONGODB
            SystemNotification systemNotification=  _repository.FindAsync<SystemNotification>(c=>c.Id==ObjectId.Parse(id)).Result?.FirstOrDefault();
#endif
            if (systemNotification != null)
            {
                Console.WriteLine(systemNotification.NotificationId);
                Console.WriteLine(systemNotification.Id);
                Console.WriteLine(systemNotification.Emails);
                Console.WriteLine(systemNotification.Bccemails);
            }
            return systemNotification;
        }
    }

   
}
