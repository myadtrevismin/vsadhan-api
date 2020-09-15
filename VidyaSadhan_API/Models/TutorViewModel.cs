using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Models
{
    public class TutorViewModel
    {
        public string Name { get; set; }
        public string ProfilePic { get; set; }
        public string Grade { get; set; }
        public string Subject { get; set; }
        public string Medium { get; set; }
        public int Rating { get; set; }
        public ICollection<CourseAssignmentViewModel> CourseAssignments { get; set; }
    }
}
