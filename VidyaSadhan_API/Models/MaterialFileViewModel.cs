using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Models
{
    public class MaterialFileViewModel
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public string FilePath { get; set; }
        public MaterialViewModel Material { get; set; }
    }
}
