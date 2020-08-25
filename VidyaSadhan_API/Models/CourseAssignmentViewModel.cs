using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Models
{
    public class CourseAssignmentViewModel
    {
        public string InstructorId { get; set; }

        public AccountViewModel Instructor { get; set; }

        public string CourseId { get; set; }

        public CourseViewModel Course { get; set; }
    }
}
