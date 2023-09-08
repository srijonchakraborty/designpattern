using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum NotificationType
    {
        None = 0,
        Email = 1,
        SMS = 2,
        EmailAndSMS = 3
    }
    public enum PurchaseOrderType
    {
        Regular=0,
        Urgent=1
    }
    public enum OrderStatus
    {
        Draft = 0,
        Pending = 1,
        Approved = 2,
        Received = 3,
        Rejected = 4,
        Cancelled = 5,
        Return = 6,
        Forward = 7,
        ForceApproved = 7,
    }

    public enum ApprovalStatus
    {
        Draft = 0,
        InReview = 1,
        Approved = 2,
        Reject = 3,
        Cancel = 4
    }
}
