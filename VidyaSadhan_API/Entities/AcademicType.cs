using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Entities
{
    public class AcademicType
    {
        [Key]
        public int AcademyTypeId { get; set; }
        public string Academy { get; set; }
    }
}
