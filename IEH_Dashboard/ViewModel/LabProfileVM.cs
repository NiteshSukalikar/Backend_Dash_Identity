using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEH_Dashboard.ViewModel
{
    public class LabProfileVM
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public long GenderId { get; set; }
        public string Gender { get; set; }
        public long CityId { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }
        public string ProfilePicture { get; set; }
        public string Status { get; set; }
        public string dob { get; set; }
    }
}
