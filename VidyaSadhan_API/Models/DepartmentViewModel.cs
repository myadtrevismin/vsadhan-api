using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Models
{
    public class DepartmentViewModel
    {
        public int DepartmentID { get; set; }

        public string Name { get; set; }

        public string Budget { get; set; }

        public DateTime StartDate { get; set; }

        public int? InstructorID { get; set; }

        public AccountViewModel Administrator { get; set; }
        public ICollection<CourseViewModel> Courses { get; set; }
    }
}
