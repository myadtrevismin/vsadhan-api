using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Models
{
    public class MaterialViewModel
    {
        public int MaterialId { get; set; }
        public string Subject { get; set; }
        public string Grade { get; set; }
        public string Title { get; set; }  
        public string Topic { get; set; }
        public IEnumerable<MaterialFileViewModel> Files { get; set; }
    }
}
