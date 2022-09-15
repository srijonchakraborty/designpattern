using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesignPattern
{
    class NotificationBuilderDirector
    {
        readonly Notification NoUseObj = new Notification();
        public void BuildNotification(INotificationBuilder notificationBuilder, Dictionary<string, dynamic> collection)
        {
            notificationBuilder.AddCCEmails(collection.ContainsKey(nameof(NoUseObj.CCEmails)) ? (collection[nameof(NoUseObj.CCEmails)] as string[]) : null)
                               .AddEmails(collection.ContainsKey(nameof(NoUseObj.Emails)) ? (collection[nameof(NoUseObj.Emails)] as string[]) : null)
                               .AddPhoneNumbers((collection.ContainsKey(nameof(NoUseObj.PhoneNumbers)) ? (collection[nameof(NoUseObj.PhoneNumbers)] as string[]) : null))
                               .SetAttachmentPaths((collection.ContainsKey(nameof(NoUseObj.AttachmentPaths)) ? (collection[nameof(NoUseObj.AttachmentPaths)] as string[]) : null))
                               .SetNotificationSubject((collection.ContainsKey(nameof(NoUseObj.NotificationSubject)) ? (collection[nameof(NoUseObj.NotificationSubject)] as string) : null))
                               .SetNotificationBody(((collection.ContainsKey(nameof(NoUseObj.NotificationBody)) ? (collection[nameof(NoUseObj.NotificationBody)] as string) : null)))
                               .SetNotificationType();
        }

       
    }
}
