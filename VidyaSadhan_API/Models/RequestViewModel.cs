using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidyaSadhan_API.Extensions;

namespace VidyaSadhan_API.Models
{
    public class RequestViewModel
    {
        public int RequestId { get; set; }
        public string TutorId { get; set; }

        public AccountViewModel Tutor { get; set; }

        public string StudentId { get; set; }

        public AccountViewModel Student { get; set; }

        public DateTime Date { get; set; }

        public string Slot { get; set; }

        public DemoViewModel Course { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public Status Status { get; set; }
    }
}
