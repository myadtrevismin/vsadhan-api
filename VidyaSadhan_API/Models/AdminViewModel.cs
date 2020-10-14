using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Models
{
    public class AdminViewModel
    {
        public int ClassesOrDemos { get; set; }
        public int Tutors { get; set; }

        public int Students { get; set; }
        public int Parents { get; set; }
        public int TotalRevinue { get; set; }
        public int NewRequests { get; set; }
    }
}
