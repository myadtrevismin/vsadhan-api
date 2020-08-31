using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Extensions
{
    public enum Status
    {
        Request,
        Approve,
        Reject,
        ReSchedule
    }

    public enum AssignmentStatus
    {
        Pending,
        Submitted,
        Evaluated
    }
}
