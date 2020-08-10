using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VidyaSadhan_API.Extensions;

namespace VidyaSadhan_API.Entities
{
    public class Enrollment
    {
        [Key]
        public int EnrollementId { get; set; }
        public string CourseId { get; set; }
        public Course Course { get; set; }
        public string StudentID { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }

        public Status Status { get; set; }


        [ForeignKey("StudentID")]
        public Account Student { get; set; }
    }
}