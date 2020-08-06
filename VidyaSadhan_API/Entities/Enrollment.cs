using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VidyaSadhan_API.Extensions;

namespace VidyaSadhan_API.Entities
{
    public class Enrollment
    {
        public int EnrollementId { get; set; }
        public int CourseID { get; set; }
        public string StudentID { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }

        [ForeignKey("CourseID")]
        public Course Course { get; set; }

        [ForeignKey("StudentID")]
        public Account Student { get; set; }
    }
}