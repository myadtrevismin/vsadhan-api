using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidyaSadhan_API.Entities;

namespace VidyaSadhan_API.Models
{
    public class StaticDataForSubjectsViewModel
    {
        public IEnumerable<State> States { get; set; }

        public IEnumerable<Subject> Subjects { get; set; }

        public IEnumerable<Group> Groups { get; set; }

        public IEnumerable<Medium> Mediums { get; set; }

        public IEnumerable<Country> Countries { get; set; }

        public IEnumerable<Board> Boards { get; set; }
    }
}
