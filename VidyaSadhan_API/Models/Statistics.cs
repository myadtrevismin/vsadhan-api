using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Models
{
    public class Statistics
    {
        public Statistics()
        {
            this.Events = new EventCounts();
            this.Materials = new Totals();
            this.Progress = new Totals();
            this.Tutors = new Totals();
            this.Earnings = new Totals();
            this.Profiles = new Totals();
        }

        public EventCounts Events { get; set; }
        public Totals Tutors { get; set; }
        public Totals Materials { get; set; }
        public Totals Progress { get; set; }
        public Totals Earnings { get; set; }
        public Totals Profiles { get; set; }

    }

    public class EventCounts: Totals
    {
        public int Demos { get; set; }
        public int Classes { get; set; }
    }

    public class Totals
    {
        public int Total { get; set; }
    }
}
