using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Models
{
    public class AccountRequestViewModel
    {
        public string FirstName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime? Birthdate { get; set; }
        public string ProfilePic { get; set; }
        public string NaCategory { get; set; }
        public string NaSubCategory { get; set; }
        public string AgeGroup { get; set; }
        public string Certification { get; set; }
        public AddressViewModel Address { get; set; }

        public InstructorViewModel Instructor { get; set; }

        public StudentViewModel Student { get; set; }
    }
}
