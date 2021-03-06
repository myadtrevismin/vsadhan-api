﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VidyaSadhan_API.Models
{
    public class AccountViewModel : UserViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRoles Role { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public string ProfilePic { get; set; }

        public string NaCategory { get; set; }

        public string NaSubCategory { get; set; }

        public string AgeGroup { get; set; }
        public string Certification { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        [BindNever]
        public List<RefreshTokenViewModel> RefreshTokens { get; set; }

        public List<AddressViewModel> Addresses { get; set; }

        public ICollection<InstructorViewModel> Instructors { get; set; }

        public ICollection<EnrolementViewModel> Enrollments { get; set; }

        public ICollection<CourseAssignmentViewModel> CourseAssignments { get; set; }

        public ICollection<StudentViewModel> Students { get; set; }

    }
}
