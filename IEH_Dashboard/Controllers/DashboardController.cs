using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using IEH_Dashboard.Common.ResponseVM;
using IEH_Dashboard.Common.StaticConstants;
using IEH_Dashboard.Model;
using IEH_Dashboard.Services.Interfaces;
using IEH_Dashboard.Utility;
using IEH_Dashboard.ViewModel.Shared;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using AuditLogVM = IEH_Dashboard.ViewModel.Shared.AuditLogVM;
using IEH_Shared.Model;
using Microsoft.AspNetCore.Http;
using IEH_Shared.Helper;

namespace IEH_Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly CommonMethods _commonMethods;

        private readonly IDashboardService _dashboardService;

        private readonly IConfiguration _configuration;

        public HttpClient Client { get; }

        public DashboardController(IDashboardService adminDashboardService, HttpClient client, IConfiguration Configuration)
        {
            _dashboardService = adminDashboardService;
            Client = client;
            _configuration = Configuration;
            _commonMethods = new CommonMethods();
        }

        [NonAction]
        public TokenClaimsModal GetUserByClaim()
        {
            HttpContext httpContext = HttpContext.Request.HttpContext;
            var claims = _commonMethods.GetUserClaimsFromToken(httpContext);
            return claims;
        }

        [HttpPost]
        [Route("GetAdminDashboardDetails")]
        public IActionResult GetAdminDashboardDetails([FromBody] FilterParameters filterModel)
        {
            var response = _dashboardService.GetAdminDashboardDetails(filterModel, GetUserByClaim());
            return Ok(new AdminResponseVM()
            {
                Data = response.DashboardList,
                ReturnCode = response.DashboardList.FirstOrDefault().ReturnCode,
                Message = IEHMessages.Success,
                StatusCode = IEHMessages.Ok
            });
        }

        [HttpPost]
        [Route("GetPharmacyDashboardDetails")]
        public IActionResult GetPharmacyDashboardDetails([FromBody] FilterParameters filterModel)
        {
            IEH_Shared.Model.ResponseModel response = _dashboardService.GetPharmacyDashboardDetails(filterModel, GetUserByClaim());
            return Ok(response);
        }

        [HttpPost]
        [Route("GetLabDashboardDetails")]
        public IActionResult GetLabDashboardDetails([FromBody] FilterParameters filterModel)
        {
            IEH_Shared.Model.ResponseModel response = _dashboardService.GetLabDashboardDetails(filterModel, GetUserByClaim());
            return Ok(response);
        }

        [HttpPost]
        [Route("GetProviderDashboardDetails")]
        public IActionResult GetProviderDashboardDetails([FromBody] ProviderDetails provider)
        {
            IEH_Shared.Model.ResponseModel response = _dashboardService.GetProviderDashboardDetails(provider, GetUserByClaim());
            return Ok(response);
        }

        [NonAction]

        public void AuditApi(AuditLogVM auditLogVM)
        {
            _dashboardService.AuditApi(auditLogVM);
        }
    }
}
