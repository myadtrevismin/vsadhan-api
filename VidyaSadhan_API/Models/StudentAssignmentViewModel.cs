using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Models
{
    public class StudentAssignmentViewModel
    {
        public int AssignmentId { get; set; }

        public AssignmentsViewModel Assignment { get; set; }

        public string UserId { get; set; }

        public AccountViewModel Account { get; set; }
    }
}
