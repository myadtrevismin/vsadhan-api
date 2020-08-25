using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Entities
{
    public class Attendance
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public Account User { get; set; }
        public string CourseId { get; set; }
        public Course Course { get; set; }
        public DateTime AttendanceDate { get; set; }
        public bool IsPresent { get; set; }
        public string Reason { get; set; }
        public string Remarks { get; set; }
    }
}
