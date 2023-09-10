using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Approval
{
    public class ApprovalHistory<TModelStatus,TStatus>where TModelStatus :struct, Enum
                                                      where TStatus : struct, Enum
    {
       public TModelStatus PreviousModelStatus { get; set; }
       public TStatus PreviousApprovalStatus { get; set; }
       public TModelStatus CurrentModelStatus { get; set; }
       public TStatus CurrentApprovalStatus { get; set; }
       public DateTime CreatedDate { get; set; }
       public string? CreatedBy { get; set; }
       public string? ReferenceId { get; set; }
       public ApprovalReferenceType ReferenceType { get; set; }
    }
}
