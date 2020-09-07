using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidyaSadhan_API.Extensions;

namespace VidyaSadhan_API.Models
{
    public class StudentAssignmentViewModel
    {
        public int AssignmentId { get; set; }

        public AssignmentsViewModel Assignment { get; set; }

        public string UserId { get; set; }

        public AccountViewModel Account { get; set; }

        public string CourseId { get; set; }

        public CourseViewModel Course { get; set; }

        public DateTime? SubmissionDate { get; set; }

        public AssignmentStatus Status { get; set; }

        public string SubmissionFile { get; set; }
    }
}
