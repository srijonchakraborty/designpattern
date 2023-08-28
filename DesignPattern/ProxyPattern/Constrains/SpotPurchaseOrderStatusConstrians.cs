using Common.Constrains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Constrains
{
    public static class SpotPurchaseOrderStatusConstrians
    {
        public static string[] ApproverOrForceApproverRoles
        {
            get
            {
                return new string[]
                {
                  Roles.Admin,
                  Roles.FinancialManger,
                };
            }
        }
        public static string[] RejectOrReturnRoles
        {
            get
            {
                return new string[]
                {
                  Roles.Admin,
                  Roles.FinancialManger,
                };
            }
        }
       
        public static string[] ReceiverRoles
        {
            get
            {
                return new string[]
                {
                    Roles.Admin,
                    Roles.Executive
                };
            }
        }
    }
}
