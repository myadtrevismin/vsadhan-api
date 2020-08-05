using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Models
{
    public class DemoViewModel
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public int? BoardId { get; set; }
        public int MediumId { get; set; }
        public int? GroupId { get; set; }
        public int AcademyTypeId { get; set; }
    }
}
