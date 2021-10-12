using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace IEH_Dashboard.ViewModel
{
    public class UserViewModel
    {
        [Required]
        [DataMember(Name = "Id")]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string License { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public bool IsStaff { get; set; }
        public string Qualification { get; set; }
        public string Tags { get; set; }
        public string PhotoPath { get; set; }
    }
}
