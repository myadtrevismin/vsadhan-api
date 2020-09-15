using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Entities
{
    public class MaterialFile
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public string FilePath { get; set; }
        public Material Material { get; set; }
    }
}
