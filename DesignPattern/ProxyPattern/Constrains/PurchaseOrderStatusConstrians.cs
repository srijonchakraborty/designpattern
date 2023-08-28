using Common.Constrains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Constrains
{
    public static class PurchaseOrderStatusConstrians
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
        public static string[] CancelOrRejectOrReturnRoles
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
        public static string[] ForwardRoles
        {
            get
            {
                return new string[]
                {
                  Roles.Admin,
                  Roles.FinancialManger,
                  Roles.Executive,
                  Roles.TechManager
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
                    Roles.FinancialManger,
                    Roles.TechManager
                };
            }
        }
    }
}
