using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Entities
{
    public class Request
    {
        public int RequestId { get; set; }
        public string TutorId { get; set; }

        public Account Tutor { get; set; }

        public string StudentId { get; set; }

        public Account Student { get; set; }

        public DateTime Date { get; set; }

        public string Slot { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}
