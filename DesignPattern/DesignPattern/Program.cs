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
using RepositoryPattern.Models;
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

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {

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

        static void RepositoryPatternInvoke(Notification finalNotification)
        {
            AppSettingsBuilder.AppSettingsBuild();

            ServiceProvider serviceProvider = SetupDb(DbTypeEnum.SqlServer);

            var repositoryPatternImplementation = ActivatorUtilities.CreateInstance<RepositoryPatternImplementation>(serviceProvider);

            SystemNotification obj = new GenericPrototype<Notification, SystemNotification>().DeepUsingJsonClone(finalNotification);
            obj.Id = ObjectId.GenerateNewId();
            repositoryPatternImplementation.Save(obj);
            string objectIdString = obj.Id.ToString();

            // Convert the string to ObjectId
            ObjectId objectId = ObjectId.Parse(objectIdString);
            var ttt=repositoryPatternImplementation.GetNotification(objectIdString);
        }

        private static ServiceProvider SetupDb(DbTypeEnum dbTypeEnum)
        {
            ServiceProvider serviceProvider = null;
            if (dbTypeEnum == DbTypeEnum.MongoDB)
            {
                serviceProvider= new ServiceCollection()
                .AddSingleton<IMongoClient>(s => new MongoClient(CustomConstant.CurrentAppSettings.MongoConnection.ConnectionString))
                .AddSingleton(s => s.GetService<IMongoClient>().GetDatabase(CustomConstant.CurrentAppSettings.MongoConnection.InstanceName))
                .AddScoped(typeof(IRepository), typeof(MongoDbRepository))
                .BuildServiceProvider();
            }
            else if (dbTypeEnum == DbTypeEnum.SqlServer)
            {

                serviceProvider = new ServiceCollection()
                .AddDbContext<SqlServerDbContext>(options =>
                {
                    options.UseSqlServer(CustomConstant.CurrentAppSettings.SqlConnection.ConnectionString);
                })
                .AddScoped(typeof(IRepository), typeof(SqlServerRepository))
                .BuildServiceProvider();
            }
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

            Notification finalMobileNotification  = myNT.GetNotification();
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
