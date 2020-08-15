using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Models
{
    public class StudentViewModel
    {
        public string UserId { get; set; }
        public AccountViewModel Account { get; set; }

        public string Board { get; set; }

        public int AcademyTypeId { get; set; }
        public AcademicTypeViewModel AcademicType { get; set; }
        public string Subjects { get; set; }

        public string Medium { get; set; }

        public string Level { get; set; }

        public string Intersets { get; set; }
    }
}
