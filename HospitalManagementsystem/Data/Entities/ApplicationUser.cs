using HospitalManagementsystem.Data.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementsystem.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Dob { get; set; }
        public string ImageUrl { get; set; }
        //public UserType UserType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt{ get; set; }
        public DateTime LastLoggedIn { get; set; }
    }
}

