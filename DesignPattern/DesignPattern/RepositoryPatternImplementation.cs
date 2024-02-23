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
#if SQLSERVER
                        await unitOfWork.SaveChangesAsync();
#endif
                        if (result is SystemNotification)
                        {
                            var tempRes = result as SystemNotification;
                            //This is just a dummy logic to check automatic rollback 
                            //Check the SQL Server Data Using SELECT * FROM SystemNotification WITH (NOLOCK) Query
#if SQLSERVER
                            if (tempRes != null && (tempRes.NotificationId % 2) == 0)
                            {
                                throw new Exception("Hululu");
                            }
#elif MONGODB
                            if (tempRes != null && (SumDigits(tempRes.Id.ToString()) % 2) == 0)
                            {
                                throw new Exception("Hululu Mongo");
                            }
#endif
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

        static int SumDigits(string input)
        {
            int sum = 0;
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    sum += int.Parse(c.ToString());
                }
            }
            return sum;
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
