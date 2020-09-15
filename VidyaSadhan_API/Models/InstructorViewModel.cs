using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Models
{
    public class InstructorViewModel
    {
        public string UserId { get; set; }

        public string Board { get; set; }

        public int AcademyTypeId { get; set; }
        public AcademicTypeViewModel AcademicType { get; set; }
        public string Subjects { get; set; }

        public string Level { get; set; }

        public bool IsTutorBefore { get; set; }

        public string ProfessionalDescription { get; set; }

        public string Preference { get; set; }

        public string AvailableDays { get; set; }

        public int PreferredDistance { get; set; }
        public string PreferredTimeSlot { get; set; }

        public string HighestEducation { get; set; }

        public double HourlyRate { get; set; }

        public string Currency { get; set; }

        public string IdType { get; set; }

        public string IdDoc { get; set; }

        public string DemoLink { get; set; }

        public string Intersets { get; set; }

        public string Name { get; set; }

        public AddressViewModel? Location { get; set; }

        public string Medium { get; set; }
        public IEnumerable<CourseAssignmentViewModel> CourseAssignments { get; set; }
        public AccountViewModel Account { get; set; }
        public ICollection<QuestionnaireViewModel> Questionnaires { get; set; }
    }
}
