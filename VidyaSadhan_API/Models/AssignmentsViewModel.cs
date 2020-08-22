using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Models
{
    public class AssignmentsViewModel
    {
        public int AssignmentId { get; set; }
        public string InstructorId { get; set; }
        public AccountViewModel Account { get; set; }
        public string Title { get; set; }
        public string Topic { get; set; }
        public string Subject { get; set; }
        public string Grade { get; set; }
        public string Points { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Instructions { get; set; }
        public string AssignmentFile { get; set; }
        public string CourseId { get; set; }
        public int QuestionSetId { get; set; }
        public ICollection<StudentAssignmentViewModel> StudentAssignments { get; set; }
    }
}
