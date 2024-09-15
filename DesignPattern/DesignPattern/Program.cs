using BuilderPattern.BuilderConcrete.NotificationBuilder;
using BuilderPattern.BuilderDirectors;
using BuilderPattern.BuilderInterface;
using Common;
using Common.Data;
using Common.DTOs.Email;
using Common.Mapper;
using Common.Model;
using Common.Model.Constants;
using Common.Model.Order;
using Common.Model.Weather;
using DecoratorPattern.Contracts;
using DecoratorPattern.DecoratorProcessor;
using DecoratorPattern.Decoretors.PurchaseOrderDecoretor;
using DesignPattern.Order;
using EmailService.Contracts;
using EmailService.Services;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PrototypePattern.Implementation;
using RabbitConsumerForNotification.Builder;
using RepositoryPattern.Contract;
using RepositoryPattern.Repository;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;
//using Repository.Models;
using DesignPattern.DBContext;
using DesignPattern.DBContext.Builder;
using DesignPattern.DBContext.Models.Models;
using RepositoryPattern.Factory;
using RepositoryPattern.UnitOfWork;
using RepositoryPattern.UnitOfWorkFactory;
using RepositoryPattern.Context;
using BuilderPattern.BuilderConcrete.OrderBuilder;
using BuilderPattern.BuilderDirectors.OrderDirector;
using Common.Contracts.Order;
using Common.DTOs.BuilderOption.Order;
using BuilderPattern.BuilderConcrete.BurgerBuilder;
using BuilderPattern.BuilderDirectors.BurgerDirector;
using Common.DTOs.Burger;
using Common.Contracts.Burger;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            BuilderPatternForBurger();
            return;
            FactoryPatternImplementation.FactoryMethodPatternImplementation();
            FactoryPatternImplementation.SimpleFactoryPatternImplementation();

            FacadePatternImplementationWithPrototypeAndMemento.FacadePatternImplementation();
            StatePatternApprovalImplementation.StatePatternImplementation();
            TempleteMethodPatternImplementation.TempleteMethodImplementation();
            ProxyPattern();
            ReportStrategyPatternImplementation();
            Console.WriteLine("Hello World!");
            Notification finalNotification = BuilderPatternImplementation();
            DecoratorImplementation.DecoratorPatternImplementation();

            RepositoryPatternInvoke(finalNotification);

            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
        }

        private static void BuilderPatternForBurger()
        {
            ChickenBurgerBuilder burgerChickenBuilder = new ChickenBurgerBuilder();
            IBurgerDirector<ChickenBurgerBuilder, ChickenBurgerDto> basicburgerDirector = new ChickenBurgerDirector();

            IBurger burgerChicken = basicburgerDirector.BuildBurger(burgerChickenBuilder, new ChickenBurgerDto()
            {
                Id = "CB001",
                BurgerCode = "CHCKN-01",
                CreateDate = DateTime.Now,
                Bun = "Sesame",
                Tomato = "Sliced",
                ChickenPatty = "Spicy",
                ChickenCrispy = "Yes"
            });

            VegetableBurgerBuilder vegetableBuilder = new VegetableBurgerBuilder();
            IBurgerDirector<VegetableBurgerBuilder, VegetableBurgerDto> basicVegetableburgerDirector = new VegetableBurgerDirector();


            IBurger burgerVeg = basicVegetableburgerDirector.BuildBurger(vegetableBuilder, new VegetableBurgerDto()
            {
                Id = "VB001",
                BurgerCode = "VEG-01",
                CreateDate = DateTime.Now,
                Bun = "Whole Wheat",
                Tomato = "Sliced",
                VegetableFriedPatty = "Spicy",
                VegetableGrilledPatty = "Grilled"
            });

            Console.WriteLine("Chicken: ......");
            Console.WriteLine(JsonConvert.SerializeObject(burgerChicken));
            
            
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Veg: ......");
            Console.WriteLine(JsonConvert.SerializeObject(burgerVeg));

            Console.ReadKey();
        }

        static void RepositoryPatternInvoke(Notification finalNotification)
        {
            AppSettingsBuilder.AppSettingsBuild();

            ServiceProvider serviceProvider = SetupDb();

            var repositoryPatternImplementation = ActivatorUtilities.CreateInstance<RepositoryPatternImplementation>(serviceProvider);

            SystemNotification obj = finalNotification.ToSystemNotification();
            obj.Id = ObjectId.Parse("65d878f775408fbf61e6c11d");
            var savedObject = repositoryPatternImplementation.SaveUsingUnitOfWork(obj).Result;

#if SQLSERVER
            string id = savedObject.NotificationId.ToString();
#elif MONGODB
           
            string id = savedObject.Id.ToString();
#endif
            var ttt = repositoryPatternImplementation.GetNotification(id).Result;
        }

        private static ServiceProvider SetupDb()
        {
            ServiceProvider serviceProvider = null;
#if SQLSERVER
            serviceProvider = new ServiceCollection()
            .AddDbContext<DesignPattern.DBContext.SQLServer.SqlServerDbContext>(options =>
            {
                options.UseSqlServer(CustomConstant.CurrentAppSettings.SqlConnection.ConnectionString);
            })
            .AddScoped(typeof(IRepository), typeof(SqlServerRepository<DesignPattern.DBContext.SQLServer.SqlServerDbContext>))
            .AddScoped<IUnitOfWork, SqlServerUnitOfWork<DesignPattern.DBContext.SQLServer.SqlServerDbContext>>()
            .AddScoped<IUnitOfWorkFactory, SqlServerUnitOfWorkFactory<DesignPattern.DBContext.SQLServer.SqlServerDbContext>>()
            .BuildServiceProvider();
#elif MONGODB

            serviceProvider = new ServiceCollection()
            .AddSingleton<IMongoClient>(s => new MongoClient(CustomConstant.CurrentAppSettings.MongoConnection.ConnectionString))
            .AddScoped<IMongoSessionContext, MongoSessionContext>()
            .AddSingleton(s => s.GetService<IMongoClient>().GetDatabase(CustomConstant.CurrentAppSettings.MongoConnection.InstanceName))
            .AddScoped<IUnitOfWork, MongoDBUnitOfWork>()
            .AddScoped<IUnitOfWorkFactory, MongoUnitOfWorkFactory>()
            .AddScoped(typeof(IRepository), typeof(MongoDbRepository))
            .BuildServiceProvider();
               
#endif
            return serviceProvider;
        }

        private static void ProxyPattern()
        {
            VirtualProxyImplementation.VirtualProxyPatternImplementation();
            RemoteProxyImplementation.RemoteProxyPatternImplementation();
            ProtectionProxyImplementation.ProtectionProxyPatternImplementation();
        }

        private static Notification BuilderPatternImplementation()
        {
            Notification noUseObj = new Notification();
            INotificationBuilder myNT = new EmailNotificationBuilder();
            NotificationBuilderDirector notificationDirector = new NotificationBuilderDirector();

            Dictionary<string, dynamic> notificationInfo = new Dictionary<string, dynamic>();
            notificationInfo.Add(nameof(noUseObj.CCEmails), new string[] { "srijoncc@yopmail.com", "srijoncc@yopmail.com" });
            notificationInfo.Add(nameof(noUseObj.Emails), new string[] { "srijon@yopmail.com" });
            notificationInfo.Add(nameof(noUseObj.NotificationSubject), "This is a Test Subject");
            //Here you can use template with dynamic feature for body
            notificationInfo.Add(nameof(noUseObj.NotificationBody), $@"This is a Notification body ID:{Guid.NewGuid().ToString()} {DateTime.UtcNow.ToLongTimeString()}");

            notificationDirector.BuildNotification(myNT, notificationInfo);

            Notification finalNotification = myNT.GetNotification();
            Console.WriteLine(finalNotification.ToString());

            //You can console log here "finalNotification"

            notificationInfo.Clear();

            myNT = new PhoneNotificationBuilder();
            notificationInfo.Add(nameof(noUseObj.PhoneNumbers), new string[2] { "0161111111", "0162222222" });
            notificationInfo.Add(nameof(noUseObj.NotificationSubject), "This is a Test Subject");
            //Here you can use template with dynamic feature for body
            notificationInfo.Add(nameof(noUseObj.NotificationBody), "This is a Notification body");

            notificationDirector.BuildNotification(myNT, notificationInfo);

            Notification finalMobileNotification = myNT.GetNotification();
            Console.WriteLine(finalMobileNotification.ToString());
            //You can console log here "finalNotification" Test 

            return finalNotification;
        }

        private static void ReportStrategyPatternImplementation()
        {
            OrderReportStrategyImplementation orderReportStrategyImplementation = new OrderReportStrategyImplementation("D:\\FileExcel");
            orderReportStrategyImplementation.GenerateReport();
            orderReportStrategyImplementation.GenerateAllInOneReport();
        }
    }

}