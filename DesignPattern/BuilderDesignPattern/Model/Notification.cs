using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesignPattern
{
    class Notification
    {
        public string[] Emails { get; set; }
        public string[] CCEmails { get; set; }
        public string[] PhoneNumbers { get; set; }
        public string NotificationSubject { get; set; }
        public string NotificationBody { get; set; }
        public string[] AttachmentPaths { get; set; }
        public NotificationType NType { get; set; }
    }
}
