using Common.Model.Order;
using Microsoft.Extensions.DependencyInjection;
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
        public RepositoryPatternImplementation(IRepository repository) 
        {
            _repository = repository;
        }
        public async Task Save<T>(T obj) where T : class
        {
            await _repository.AddAsync(obj);
        }
    }
}
