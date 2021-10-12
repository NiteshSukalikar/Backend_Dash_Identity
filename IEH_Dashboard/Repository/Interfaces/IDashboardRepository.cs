namespace IEH_Dashboard.Repository.Interfaces
{
    using IEH_Dashboard.Model;
    using IEH_Dashboard.ViewModel;
    using AuditLogVM = IEH_Dashboard.ViewModel.Shared.AuditLogVM;
    using IEH_Shared.Model;
    using System.Threading.Tasks;

    /// <summary>
    /// The IAdminDashboardRepository
    /// </summary>
    public interface IDashboardRepository
    {
        DashboardDataModel GetAdminDashboardDetails(FilterParameters filterModel, TokenClaimsModal claims);

        PharmacyDashboardVM GetPharmacyDashboardDetails(FilterParameters filterModel, TokenClaimsModal claims);
        LabDashboardVM GetLabDashboardDetails(FilterParameters filterModel, TokenClaimsModal claims);

        ProviderDashboardDetailsVM GetProviderDashboardDetails(ProviderDetails provider, TokenClaimsModal claims);
        
        void AuditApi(AuditLogVM auditLogVM);
    }
}
