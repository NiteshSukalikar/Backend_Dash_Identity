namespace IEH_Dashboard.Implementations
{
    using IEH_Dashboard.Common.StaticConstants;
    using IEH_Dashboard.Model;
    using IEH_Dashboard.Repository.UnitOfWorkAndBaseRepo;
    using IEH_Dashboard.Services.Interfaces;
    using IEH_Dashboard.ViewModel;
    using IEH_Dashboard.ViewModel.Shared;
    using IEH_Shared.Enum;
    using IEH_Shared.Model;
    using System;
    using System.Threading.Tasks;
    using AuditLogVM = IEH_Dashboard.ViewModel.Shared.AuditLogVM;

    public class DashboardService : IDashboardService
    {
        internal IUnitOfWork _unitOfWork;
        
        public DashboardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DashboardDataModel GetAdminDashboardDetails(FilterParameters filterModel, TokenClaimsModal claims)
        {
            var adminDashboardList = _unitOfWork.AdminDashboard.GetAdminDashboardDetails(filterModel, claims);
            return adminDashboardList;
        }

        public IEH_Shared.Model.ResponseModel GetPharmacyDashboardDetails(FilterParameters filterModel, TokenClaimsModal claims)
        {
            IEH_Shared.Model.ResponseModel response = new IEH_Shared.Model.ResponseModel();
            try
            {
                PharmacyDashboardVM dashboard = _unitOfWork.AdminDashboard.GetPharmacyDashboardDetails(filterModel, claims);
                if (dashboard != null)
                {
                    response.StatusCode = ((int)StatusCode.StatusCode200).ToString();
                    response.Data = dashboard;
                    response.Message = IEHMessages.OperationSuccessful;
                }
                else
                {
                    response.StatusCode = ((int)StatusCode.StatusCode205).ToString();
                    response.Data = null;
                    response.Message = IEHMessages.RequestCoundNotProceed;
                }

                return response;
            }
            catch (Exception e)
            {
                return response;
            }
        }

        public IEH_Shared.Model.ResponseModel GetLabDashboardDetails(FilterParameters filterModel, TokenClaimsModal claims)
        {
            IEH_Shared.Model.ResponseModel response = new IEH_Shared.Model.ResponseModel();
            try
            {
                LabDashboardVM dashboard = _unitOfWork.AdminDashboard.GetLabDashboardDetails(filterModel, claims);
                if (dashboard != null)
                {
                    response.StatusCode = ((int)StatusCode.StatusCode200).ToString();
                    response.Data = dashboard;
                    response.Message = IEHMessages.OperationSuccessful;
                }
                else
                {
                    response.StatusCode = ((int)StatusCode.StatusCode205).ToString();
                    response.Data = null;
                    response.Message = IEHMessages.RequestCoundNotProceed;
                }

                return response;
            }
            catch (Exception e)
            {
                return response;
            }
        }


       
        /// <summary>
        /// The AuditApi
        /// </summary>
        /// <param name="auditLogVM">The auditLogVM<see cref="AuditLogVM"/></param>
        public void AuditApi(AuditLogVM auditLogVM)
        {
            _unitOfWork.AdminDashboard.AuditApi(auditLogVM);
        }

        public IEH_Shared.Model.ResponseModel GetProviderDashboardDetails(ProviderDetails provider, TokenClaimsModal claims)
        {
            IEH_Shared.Model.ResponseModel response = new IEH_Shared.Model.ResponseModel();
            try
            {
                ProviderDashboardDetailsVM _provider = _unitOfWork.AdminDashboard.GetProviderDashboardDetails(provider, claims);
                if (provider != null)
                {

                    response.StatusCode = ((int)StatusCode.StatusCode200).ToString();
                    response.Data = _provider;
                    response.Message = IEHMessages.OperationSuccessful;
                }
                else
                {
                    response.StatusCode = ((int)StatusCode.StatusCode201).ToString();
                    response.Data = null;
                    response.Message = IEHMessages.OperationSuccessful;
                }
                return response;
            }
            catch (Exception e)
            {
                return response;
            }
        }
    }
}
