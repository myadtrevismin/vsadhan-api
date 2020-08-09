using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidyaSadhan_API.Entities
{
    public class CourseAssignment
    {
        public string InstructorId { get; set; }

        public Account Instructor { get; set; }

        public string CourseId { get; set; }

        public Course Course { get; set; }
    }
}