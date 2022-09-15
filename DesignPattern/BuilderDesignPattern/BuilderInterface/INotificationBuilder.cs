using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesignPattern
{
    interface INotificationBuilder
    {
        INotificationBuilder AddEmails(string[] emails);
        INotificationBuilder AddCCEmails(string[] emailCCs);
        INotificationBuilder SetNotificationSubject(string subject);
        INotificationBuilder SetNotificationBody(string body);
        INotificationBuilder SetAttachmentPaths(string[] attachmentPaths);
        INotificationBuilder AddPhoneNumbers(string[] phoneNumbers);
        INotificationBuilder SetNotificationType();
        Notification GetNotification();
    }
}
