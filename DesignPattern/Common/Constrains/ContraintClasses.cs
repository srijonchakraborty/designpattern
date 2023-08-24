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
}
