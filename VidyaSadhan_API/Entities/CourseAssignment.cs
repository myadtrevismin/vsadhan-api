using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidyaSadhan_API.Entities
{
    public class CourseAssignment
    {

        public string InstructorId { get; set; }

        public int CourseId { get; set; }


        [ForeignKey("InstructorId")]
        public Account Instructor { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }
    }
}