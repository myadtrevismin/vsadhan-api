using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Entities
{
    public class StudentAssignment
    {
        public int AssignmentId { get; set; }

        public Assignment Assignment { get; set; }

        [ForeignKey("Account")]
        public string UserId { get; set; }

        public Account Account { get; set; }
    }
}
