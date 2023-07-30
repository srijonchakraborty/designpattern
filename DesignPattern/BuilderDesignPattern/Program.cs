using BuilderPattern;
using Common;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Notification noUseObj = new Notification();
            INotificationBuilder myNT = new EmailNotificationBuilder();
            NotificationBuilderDirector notificationDirector = new NotificationBuilderDirector();
       
            Dictionary<string, dynamic> notificationInfo = new Dictionary<string, dynamic>();
            notificationInfo.Add(nameof(noUseObj.CCEmails), new string[2] { "srijoncc@gmail.com", "srijoncc@live.com"});
            notificationInfo.Add(nameof(noUseObj.Emails), new string[2] { "srijon@gmail.com", "srijon@live.com" });
            notificationInfo.Add(nameof(noUseObj.NotificationSubject), "This is a Test Subject");
            //Here you can use template with dynamic feature for body
            notificationInfo.Add(nameof(noUseObj.NotificationBody), "This is a Notification body");
            
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
            
            finalNotification = myNT.GetNotification();
            Console.WriteLine(finalNotification.ToString());
            //You can console log here "finalNotification" Test 
        }
    }

}
