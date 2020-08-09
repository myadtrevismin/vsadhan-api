using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Entities
{
    public class CourseSubject
    {
        public string CourseId { get; set; }

        public Course Course { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
