using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public int? BoardId { get; set; }
        public Board Board { get; set; }
        public int MediumId { get; set; }
        public Medium Medium { get; set; }
        public int? GroupId { get; set; }
        public Group Group { get; set; }
        public int AcademyTypeId { get; set; }
        public AcademicType AcademicType { get; set; } 
    }
}
