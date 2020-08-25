using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Entities
{
    public class Course
    {
        public Course()
        {
           
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CourseId { get; set; }

        [StringLength(150, MinimumLength = 3)]
        public string Title { get; set; }

        public string CourseDescription { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Range(0, 5)]
        public int Credits { get; set; }

        public string ExternalCourseId { get; set; }

        public string Langitude { get; set; }
        public string Latitude { get; set; }
        public string LocationId { get; set; }
        public string LocationName { get; set; }
        public bool IsDemo { get; set; }

        public int? DepartmentID { get; set; }

        public Department Department { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<CourseSubject> CourseSubjects { get; set; }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}
