﻿using BuilderPattern;
using BuilderPattern.BuilderConcrete.NotificationBuilder;
using Common;
using Common.DTOs.Email;
using Common.Model.Order;
using DecoratorPattern.Contracts;
using DecoratorPattern.DecoratorProcessor;
using DecoratorPattern.Decoretors.PurchaseOrderDecoretor;
using DesignPattern.Order;
using EmailService.Contracts;
using EmailService.Services;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ReportStrategyPatternImplementation();
            Console.WriteLine("Hello World!");
            Notification finalNotification = BuilderPatternImplementation();
            DecoratorImplementation.DecoratorPatternImplementation();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
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
