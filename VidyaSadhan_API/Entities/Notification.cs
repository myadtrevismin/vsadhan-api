using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
        public string UserId { get; set; }
        public string OriginId { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
