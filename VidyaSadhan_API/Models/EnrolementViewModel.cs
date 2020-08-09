using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidyaSadhan_API.Extensions;

namespace VidyaSadhan_API.Models
{
    public class EnrolementViewModel
    {
        public int EnrollementId { get; set; }
        public string CourseId { get; set; }

        [JsonIgnore]
        public CourseViewModel Course { get; set; }
        public string StudentID { get; set; }
        public Grade? Grade { get; set; }

        public AccountViewModel Student { get; set; }
    }
}
