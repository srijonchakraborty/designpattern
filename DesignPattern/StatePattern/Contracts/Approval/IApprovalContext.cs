using Common;
using Common.Contracts.Order;
using Common.Model.Approval;
using StatePattern.Implementation.Approval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.Contracts.Approval
{
    public interface IApprovalContext<T, TModelStatus, TStatus>
       where T : class
       where TModelStatus : struct, Enum
       where TStatus : struct, Enum
    {
        IApprovalState<T, TModelStatus, TStatus> CurrentApprovalState { get; }
        T CurrentObject { get; }
        List<ApprovalHistory<TModelStatus, TStatus>> GetAllApprovalHistory();
        void ProcessToNext(TStatus from, TStatus to, TModelStatus toModelStatus,string performBy);
        void SetCurrentApprovalState(IApprovalState<IOrder, OrderStatus, ApprovalStatus> currentApprovalState);
    }
}
