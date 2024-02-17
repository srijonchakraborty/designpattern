using Common.Model;
using Common.Model.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using RepositoryPattern.Contract;
using RepositoryPattern.Models;
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
        public SystemNotification GetNotification(string obj)
        {
            //var item = await _repository.GetByIdAsync<SystemNotification>(obj);
            //Console.WriteLine(item.Id);
            //Console.WriteLine(item.Emails.Length);
            
            //Console.WriteLine("----Using find-----");
            
            var items = _repository.Find<SystemNotification>(c=>c.Id==ObjectId.Parse(obj));
            var final = items.ToList();
            Console.WriteLine(final.Count);
            Console.WriteLine(final[0].Emails.Length);
            Console.WriteLine(final[0].Id);
            return final[0];
        }
    }

    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer(@"Your conn string");
        }
        public DbSet<SystemNotification> SystemNotifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemNotification>().HasKey(n => n.NotificationId);
        }
    }
}
