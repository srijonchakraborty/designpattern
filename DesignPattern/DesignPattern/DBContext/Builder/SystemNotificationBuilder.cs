using Common.Model;
using DesignPattern.DBContext.Models.Models;
using MongoDB.Bson;

namespace DesignPattern.DBContext.Builder
{
    public static class SystemNotificationBuilder
    {
        public static SystemNotification ToSystemNotification(this Notification notification)
        {
            var systemNotification = new SystemNotification
            {
                //check in this projects csproj file<DefineConstants>SQLSERVER</DefineConstants>
                #if SQLSERVER
                NotificationId = 0, 
                #elif MONGODB
                Id = ObjectId.GenerateNewId(), 
                #endif
                Emails = notification.Emails != null ? string.Join(",", notification.Emails) : null,
                Ccemails = notification.CCEmails != null ? string.Join(",", notification.CCEmails) : null,
                Bccemails = notification.BCCEmails != null ? string.Join(",", notification.BCCEmails) : null,
                PhoneNumbers = notification.PhoneNumbers != null ? string.Join(",", notification.PhoneNumbers) : null,
                NotificationSubject = notification.NotificationSubject,
                NotificationBody = notification.NotificationBody,
                AttachmentPaths = notification.AttachmentPaths != null ? string.Join(",", notification.AttachmentPaths) : null,
                #if SQLSERVER
                                NType = (int?)notification.NType
                #elif MONGODB
                            NType = notification.NType
                #endif
            };

            return systemNotification;
        }
    }
}
