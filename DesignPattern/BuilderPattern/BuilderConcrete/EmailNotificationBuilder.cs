using Common;


namespace BuilderPattern
{
    public class EmailNotificationBuilder : INotificationBuilder
    {
        Notification currentNofication = new Notification();
        public INotificationBuilder AddEmails(string[] emails)
        {
            currentNofication.Emails = emails;
            return this;
        }

        public INotificationBuilder AddCCEmails(string[] emailCCs)
        {
            currentNofication.CCEmails = emailCCs;
            return this;
        }

        public INotificationBuilder AddPhoneNumbers(string[] phoneNumbers)
        {
            currentNofication.PhoneNumbers = phoneNumbers;
            return this;
        }

        public INotificationBuilder SetAttachmentPaths(string[] attachmentPaths)
        {
            currentNofication.AttachmentPaths = attachmentPaths;
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
            currentNofication.NType = NotificationType.Email;
            return this;
        }
        public Notification GetNotification()
        {
            return currentNofication;
        }
    }

}
