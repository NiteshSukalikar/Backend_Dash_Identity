using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using IEH_Identity.Common;
using IEH_Identity.Entity;
using IEH_Identity.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IEH_Identity.Data
{
    public interface IAuthRepository
    {
        User GetUserById(string id);
        User GetUserByUsername(string username);
        bool ValidatePassword(string username, string plainTextPassword);
    }

    public class AuthRepository : IAuthRepository
    {
        private ApplicationDbContext db;

        private readonly IDataService _dataService;


        public AuthRepository(ApplicationDbContext context, IDataService dataService)
        {
            db = context;
            _dataService = dataService;
        }

        public User GetUserById(string id)
        {
            var user = _dataService.GetUserById(id);
            //  var user = db.Users.Where(u => u.Id == id).FirstOrDefault();
            return user;
        }

        public User GetUserByUsername(string username)
        {
            var user = _dataService.GetUserByEmail(username);
            // var user = db.Users.Where(u => String.Equals(u.Email, username)).FirstOrDefault();
            return user;
        }


        public bool ValidatePassword(string username, string plainTextPassword)
        {
            var user = _dataService.GetUserByEmail(username);

            //  var user = db.Users.Where(u => String.Equals(u.Email, username)).FirstOrDefault();
            if (user == null) return false;
            if (String.Equals(plainTextPassword, user.Password)) return true;
            return false;
        }
    }

    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        IAuthRepository _rep;

        public ResourceOwnerPasswordValidator(IAuthRepository rep)
        {
            this._rep = rep;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if (_rep.ValidatePassword(context.UserName, context.Password))
            {
                var data = _rep.GetUserByUsername(context.UserName);
                context.Result = new GrantValidationResult(data.UserId.ToString(), "password", null, "local", null);
                return Task.FromResult(context.Result);
            }
            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, Constants.InvalidCredentialsErrorMessage, null);
            return Task.FromResult(context.Result);
        }
    }

    public class ProfileService : IProfileService
    {
        private IAuthRepository _repository;

        public ProfileService(IAuthRepository rep)
        {
            this._repository = rep;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                var subjectId = context.Subject.GetSubjectId();
                var user = _repository.GetUserById(subjectId);

                var claims = new List<Claim>
                {   new Claim("UserId", user.UserId.ToString()),
                    new Claim("RoleId", user.RoleId.ToString()),
                    new Claim("UserName", user.UserName.ToString()),
                    new Claim("EmailAddress", user.EmailAddress.ToString()),
                    new Claim("FirstName", user.FirstName.ToString()),
                    new Claim("LastName", user.LastName.ToString()),
                    new Claim("Gender", user.Gender != null ? user.Gender.ToString():"1"),
                    new Claim("FullName", user.FullName != null ? user.FullName.ToString() : string.Concat(user.FirstName," ",user.LastName)),
                    new Claim("ContactNumber", user.ContactNumber.ToString()),
                    new Claim("StaffId",user.StaffId !=null ? user.StaffId.ToString() : "0"),
                    new Claim("PatientId",user.PatientId.ToString()),
                    new Claim("OrganizationId",user.OrganizationId.ToString()),
                    new Claim("OrganizationName",user.OrganizationName.ToString()),
                    new Claim("StaffName",user.StaffName.ToString()),
                    new Claim("UserType",user.UserType.ToString()),
                    new Claim("ProviderTypeId",user.ProviderTypeId != null ? user.ProviderTypeId.ToString() : "0"),
                    new Claim("ProviderTypeName",user.ProviderTypeName != null ? user.ProviderTypeName.ToString() : ""),
                    new Claim("PharmacyId",user.PharmacyId != null ? user.PharmacyId.ToString() : "0"),
                    new Claim("LabId",user.LabId != null ? user.LabId.ToString() : "0"),
                    new Claim("IsNotificationActive", user.IsNotificationActive ? "true" : "false"),
                    new Claim("WalletBalance",user.WalletBalance != null ? user.WalletBalance.ToString() : "0"),

                    //add as many claims as you want!new Claim(JwtClaimTypes.Email, user.Email),new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean)
                };

                context.IssuedClaims = claims;
                return Task.FromResult(0);
            }
            catch (Exception x)
            {
                return Task.FromResult(0);
            }
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            var user = _repository.GetUserById(context.Subject.GetSubjectId());
            context.IsActive = (user != null) && user.Status;
            return Task.FromResult(0);
        }
    }

}
