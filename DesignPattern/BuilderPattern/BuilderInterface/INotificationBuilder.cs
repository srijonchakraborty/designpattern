using Common;

namespace BuilderPattern
{
    public interface INotificationBuilder
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
