using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Models
{
    public class ClassRequestModel_B
    {
        public string title { get; set; }
        public string timezone { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string date { get; set; }
        public string currency { get; set; }
        public string ispaid { get; set; }
        public string is_recurring { get; set; }
        public string repeat { get; set; }
        public string weekdays { get; set; }
        public string end_classes_count { get; set; }
        public string end_date { get; set; }
        public string seat_attendees { get; set; }
        public string record { get; set; }
        public string isRecordingLayout { get; set; }
        public string isVideo { get; set; }
        public string isBoard { get; set; }
        public string isLang { get; set; }
        public string isRegion { get; set; }
        public string isCorporate { get; set; }
        public string isScreenshare { get; set; }
        public string isPrivateChat { get; set; }
        public string format { get; set; }
    }
}
