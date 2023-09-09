using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.Contracts.Approval
{
    public interface IApprovalState<T, TModelStatus, TStatus>
      where T : class
      where TModelStatus : struct, Enum
      where TStatus : struct, Enum
    {
        void Process(IApprovalContext<T, TModelStatus, TStatus> context, TModelStatus modelStatus, TStatus statusApproval);
    }
}
