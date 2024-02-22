using BuilderPattern.BuilderInterface;
using Common;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.BuilderConcrete.NotificationBuilder
{
    public class PhoneNotificationBuilder : INotificationBuilder
    {
        Notification currentNofication = new Notification();
        public INotificationBuilder AddEmails(string[] emails)
        {
            return this;
        }

        public INotificationBuilder AddCCEmails(string[] emailCCs)
        {
            return this;
        }

        public INotificationBuilder AddPhoneNumbers(string[] phoneNumbers)
        {
            currentNofication.PhoneNumbers = phoneNumbers;
            return this;
        }

        public INotificationBuilder SetAttachmentPaths(string[] attachmentPaths)
        {
            return this;
        }

        public INotificationBuilder SetNotificationBody(string body)
        {
            currentNofication.NotificationBody = body;
            return this;
        }

        public INotificationBuilder SetNotificationSubject(string subject)
        {
            currentNofication.NotificationSubject = subject;
            return this;
        }

        public INotificationBuilder SetNotificationType()
        {
            currentNofication.NType = NotificationType.SMS;
            return this;
        }
        public Notification GetNotification()
        {
            return currentNofication;
        }
    }
}
