using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IEH_Identity.Entity
{
    public class User : IdentityUser
    {
        [Key]
        public string Id { get; set; }
        public long UserId { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public long RoleId { get; set; }
        public string RoleName { get; set; }
        public bool Active { get; set; }
        public bool Status { get; set; }
        public long? StaffId { get; set; }
        public int? OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public long? PatientId { get; set; }
        public string ContactNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string StaffName { get; set; }
        public int UserType { get; set; }
        public int? ProviderTypeId { get; set; }
        public string ProviderTypeName { get; set; }
        public int? PharmacyId { get; set; }
        public int? LabId { get; set; }
        public bool IsNotificationActive { get; set; }
        public decimal? WalletBalance { get; set; }
    }
}
