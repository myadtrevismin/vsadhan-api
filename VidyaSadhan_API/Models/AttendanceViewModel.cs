using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Models
{
    public class AttendanceViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        [JsonIgnore]
        public CourseViewModel Course { get; set; }

        [JsonIgnore]
        public AccountViewModel User { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CourseId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public bool? IsPresent { get; set; }
        public string Reason { get; set; }
        public string Remarks { get; set; }
    }
}
