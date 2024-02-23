using Common.Model;
using Common.Model.Order;
using DesignPattern.DBContext.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
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
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public RepositoryPatternImplementation(IRepository repository, IUnitOfWorkFactory unitOfWorkFactory) 
        {
            _repository = repository;
            _unitOfWorkFactory= unitOfWorkFactory;
        }
        public async Task<T> Save<T>(T obj) where T : class
        {
            var result= await _repository.AddAsync(obj);
            await _repository.SaveChangesAsync();
            return result;
        }
        public async Task<T> SaveUsingUnitOfWork<T>(T obj) where T : class
        {
            T result = null;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    await unitOfWork.ExecuteInTransactionAsync(async () =>
                    {
                        result = await _repository.AddAsync(obj);
                        await unitOfWork.SaveChangesAsync();
                        if (result is SystemNotification)
                        {
                            var tempRes = result as SystemNotification;
                            if (tempRes != null && (tempRes.NotificationId % 2) == 0)
                            {
                                throw new Exception("Hululu");
                            }
                        }
                        return true;
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occurred: {ex.Message}");
                }
            }
            return result;
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
