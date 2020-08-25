using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Entities
{
    public class Student
    {
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public Account Account { get; set; }
        public string Board { get; set; }

        public int AcademyTypeId { get; set; }
        public AcademicType AcademicType { get; set; }
        public string Subjects { get; set; }

        public string Level { get; set; }
        public string Medium { get; set; }


        public string Intersets { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
