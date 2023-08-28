using Common.Model.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Constrains
{
    public static class OrderTypeNames
    {
        public const string LCModel = nameof(LC);
        public const string POModel = nameof(PurchaseOrder);
        public const string SPOModel = nameof(SpotPurchase);
    }

    public static class Roles
    {
        public const string Admin = nameof(Admin);
        public const string TechManager = nameof(TechManager);
        public const string FinancialManger = nameof(FinancialManger);
        public const string Executive = nameof(Executive);
        public const string User = nameof(User);
    }
}
