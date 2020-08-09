using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Entities
{
    public class Instructor
    {
        public Instructor()
        {
            //CourseAssignments = new HashSet<CourseAssignment>();
            //Questionnaires = new HashSet<Questionnaire>();
        }
        public string UserId { get; set; }

        public string MyProperty { get; set; }

        public string Board { get; set; }

        public int AcademyTypeId { get; set; }
        public AcademicType AcademicType { get; set; }
        public string Subjects { get; set; }

        public string Level { get; set; }

        public bool IsTutorBefore { get; set; }

        public string ProfessionalDescription { get; set; }

        public string HighestEducation { get; set; }

        public string Preference { get; set; }

        public string AvailableDays { get; set; }

        public int PreferredDistance { get; set; }
        public string PreferredTimeSlot { get; set; }

        public double HourlyRate { get; set; }

        public string Currency { get; set; }

        public string IdType { get; set; }

        public string IdDoc { get; set; }

        public string DemoLink { get; set; }

        public string Intersets { get; set; }

        public string Medium { get; set; }

        [ForeignKey("UserId")]
        public virtual Account Account { get; set; }
        public ICollection<Questionnaire> Questionnaires { get; set; }
    }
}
