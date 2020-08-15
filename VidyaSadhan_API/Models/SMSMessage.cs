using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Models
{
    public class SMSMessage
    {
      
    }

    public class SMSoptions
    {
        public string SMSAccountIdentification { get; set; }
        public string SMSAccountPassword { get; set; }
        public string SMSAccountFrom { get; set; }
        public string SMSAccountUrl { get; set; }
        public string Sender { get; set; }
    }
}
