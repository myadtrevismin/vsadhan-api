using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VS_Models;

namespace VidyaSadhan_API.Models
{
    public class CourseViewModel
    {
        public VCourse VCourse { get; set; }
        public IEnumerable<VTeacher> VTeachers { get; set; }

        public string CourseId { get; set; }
        public string Title { get; set; }

        public int Credits { get; set; }

        public int? DepartmentID { get; set; }
        public string AdminId { get; set; }

        public string ExternalCourseId { get; set; }

        public string Langitude { get; set; }
        public string Latitude { get; set; }
        public string LocationId { get; set; }
        public string LocationName { get; set; }
        public bool IsDemo { get; set; }

        public CalendarEvent CalendarEvent { get; set; }

        public DepartmentViewModel Department { get; set; }
        public ICollection<EnrolementViewModel> Enrollments { get; set; }
        public ICollection<CourseAssignmentViewModel> CourseAssignments { get; set; }
        public string CourseDescription { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<CourseSubjectViewModel> CourseSubjects { get; set; }

    }
}
