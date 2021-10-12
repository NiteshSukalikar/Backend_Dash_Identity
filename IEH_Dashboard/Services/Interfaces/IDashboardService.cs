namespace IEH_Dashboard.Services.Interfaces
{
    using IEH_Dashboard.Model;
    using IEH_Dashboard.ViewModel;
    using IEH_Dashboard.ViewModel.Shared;
    using IEH_Shared.Model;
    using System.Threading.Tasks;
    using AuditLogVM = IEH_Dashboard.ViewModel.Shared.AuditLogVM;

    /// <summary>
    /// Defines the <see cref="IDashboardService" />
    /// </summary>
    public interface IDashboardService
    {
        DashboardDataModel GetAdminDashboardDetails(FilterParameters filterModel, TokenClaimsModal claims);

        IEH_Shared.Model.ResponseModel GetPharmacyDashboardDetails(FilterParameters filterModel, TokenClaimsModal claims);
        IEH_Shared.Model.ResponseModel GetLabDashboardDetails(FilterParameters filterModel, TokenClaimsModal claims);

        IEH_Shared.Model.ResponseModel GetProviderDashboardDetails(ProviderDetails provider, TokenClaimsModal claims);

        void AuditApi(AuditLogVM auditLogVM);
    }
}
