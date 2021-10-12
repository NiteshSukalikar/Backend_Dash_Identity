namespace IEH_Dashboard.Repository.Implementations
{
    using IEH_Dashboard.Common.StaticConstants;
    using IEH_Dashboard.Infrastructure.DataAccess;
    using IEH_Dashboard.Model;
    using IEH_Dashboard.Repository.Interfaces;
    using IEH_Dashboard.ViewModel.Shared;
    using System;
    using System.Data;
    using Microsoft.Data.SqlClient;
    using System.Linq;
    using IEH_Dashboard.ViewModel;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AuditLogVM = IEH_Dashboard.ViewModel.Shared.AuditLogVM;
    using IEH_Shared.Model;

    /// <summary>
    /// Defines the <see cref="DashboardRepository" />
    /// </summary>
    public class DashboardRepository : IDashboardRepository
    {
        protected readonly IEHDbContext _IEHDbContext;

        public DashboardRepository(IEHDbContext IEHDbContext)
        {
            _IEHDbContext = IEHDbContext;
        }

        public DashboardDataModel GetAdminDashboardDetails(FilterParameters filterModel, TokenClaimsModal claims)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@UserId",claims.UserId)
                };
                var connection = _IEHDbContext.GetDbConnection();
                DashboardDataModel result = new DashboardDataModel();
                try
                {
                    if (connection.State == ConnectionState.Closed) { connection.Open(); }
                    using (var cmd = connection.CreateCommand())
                    {
                        _IEHDbContext.AddParametersToDbCommand(SpConstants.GetProviderDashboardDetails, param, cmd);
                        using (var reader = cmd.ExecuteReader())
                        {
                            result.DashboardList = _IEHDbContext.DataReaderMapToList<Dashboard>(reader).ToList();
                            reader.NextResult();
                        }
                    }
                    return result;
                }
                finally
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PharmacyDashboardVM GetPharmacyDashboardDetails(FilterParameters filterModel, TokenClaimsModal claims)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@UserId",claims.UserId),
                    new SqlParameter("@OrganizationId",filterModel.OrganizationId)
                };
                var connection = _IEHDbContext.GetDbConnection();
                PharmacyDashboardVM result = new PharmacyDashboardVM();
                result.PharmacyDetails = null;
                try
                {
                    if (connection.State == ConnectionState.Closed) { connection.Open(); }
                    using (var cmd = connection.CreateCommand())
                    {
                        _IEHDbContext.AddParametersToDbCommand(SpConstants.GetPharmacyDashboardDetails, param, cmd);
                        using (var reader = cmd.ExecuteReader())
                        {
                            List<PharmacyDashboardVM> _Plist = _IEHDbContext.DataReaderMapToList<PharmacyDashboardVM>(reader).ToList();
                            result = _Plist != null && _Plist.Count > 0 ? _Plist[0] : null;
                            reader.NextResult();

                            List<PharmacyDetailsVM> _list = _IEHDbContext.DataReaderMapToList<PharmacyDetailsVM>(reader).ToList();
                            if (_list != null && _list.Count > 0)
                                result.PharmacyDetails = _list[0];
                            reader.NextResult();

                            result.Messages = _IEHDbContext.DataReaderMapToList<MessageVM>(reader).ToList();
                            reader.NextResult();
                        }
                    }
                    return result;
                }
                finally
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LabDashboardVM GetLabDashboardDetails(FilterParameters filterModel, TokenClaimsModal claims)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@UserId",claims.UserId)
                };
                var connection = _IEHDbContext.GetDbConnection();
                LabDashboardVM result = new LabDashboardVM();
                try
                {
                    if (connection.State == ConnectionState.Closed) { connection.Open(); }
                    using (var cmd = connection.CreateCommand())
                    {
                        _IEHDbContext.AddParametersToDbCommand(SpConstants.GetLabDashboardDetails, param, cmd);
                        using (var reader = cmd.ExecuteReader())
                        {
                            List<LabDashboardVM> _Plist = _IEHDbContext.DataReaderMapToList<LabDashboardVM>(reader).ToList();
                            result = _Plist != null && _Plist.Count > 0 ? _Plist[0] : null;
                            reader.NextResult();

                            List<LabProfileVM> _list = _IEHDbContext.DataReaderMapToList<LabProfileVM>(reader).ToList();
                            result.LabProfile = _list != null && _list.Count > 0 ? _list[0] : null;
                            reader.NextResult();

                            List<OrdersByCurrentMonth> _Olist = _IEHDbContext.DataReaderMapToList<OrdersByCurrentMonth>(reader).ToList();
                            result.OrdersByCurrentMonth = _Olist != null && _Olist.Count > 0 ? _Olist[0] : null;
                            reader.NextResult();

                            result.LabCustomers = _IEHDbContext.DataReaderMapToList<LabCustomersVM>(reader).ToList();
                            reader.NextResult();

                        }
                    }
                    return result;
                }
                finally
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ProviderDashboardDetailsVM GetProviderDashboardDetails(ProviderDetails provider, TokenClaimsModal claims)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@UserId",claims.UserId),
                };
                var connection = _IEHDbContext.GetDbConnection();
                ProviderDashboardDetailsVM result = new ProviderDashboardDetailsVM();
                try
                {
                    if (connection.State == ConnectionState.Closed) { connection.Open(); }
                    using (var cmd = connection.CreateCommand())
                    {
                        _IEHDbContext.AddParametersToDbCommand(SpConstants.GetProviderDashboard, param, cmd);
                        using (var reader = cmd.ExecuteReader())
                        {
                            var _UserList = _IEHDbContext.DataReaderMapToList<UserViewModel>(reader).ToList();
                            result.UserDetails = _UserList != null && _UserList.Count != 0 ? _UserList[0] : new UserViewModel();
                            if (result.UserDetails.PhotoPath != null && result.UserDetails.PhotoPath != "" && result.UserDetails.PhotoPath != String.Empty)
                            {
                                result.UserDetails.PhotoPath = Constants.ImagePath + result.UserDetails.PhotoPath;
                            }
                            reader.NextResult();

                            var _NextAppointment = _IEHDbContext.DataReaderMapToList<UpcommingAppointment>(reader).ToList();
                            result.UpcommingAppointment = _NextAppointment != null && _NextAppointment.Count != 0 ? _NextAppointment : new List<UpcommingAppointment>();
                            reader.NextResult();

                            var _CancelledAppointment = _IEHDbContext.DataReaderMapToList<UpcommingAppointment>(reader).ToList();
                            result.CancelledAppointment = _CancelledAppointment != null && _CancelledAppointment.Count != 0 ? _CancelledAppointment : new List<UpcommingAppointment>();
                            reader.NextResult();

                            var _TodayAppointment = _IEHDbContext.DataReaderMapToList<UpcommingAppointment>(reader).ToList();
                            result.TodayAppointment = _TodayAppointment != null && _TodayAppointment.Count != 0 ? _TodayAppointment : new List<UpcommingAppointment>();
                            reader.NextResult();

                            var _Messages = _IEHDbContext.DataReaderMapToList<MessageViewModel>(reader).ToList();
                            result.Messages = _Messages != null && _Messages.Count != 0 ? _Messages : new List<MessageViewModel>();
                            reader.NextResult();

                            var _CompletedAmountList = _IEHDbContext.DataReaderMapToList<CompleteAmount>(reader).ToList();
                            result.CmpAmount = _CompletedAmountList != null && _CompletedAmountList.Count != 0 ? _CompletedAmountList[0] : new CompleteAmount();
                            reader.NextResult();

                            var _PendingAmountList = _IEHDbContext.DataReaderMapToList<PendAmount>(reader).ToList();
                            result.PndAmount = _PendingAmountList != null && _PendingAmountList.Count != 0 ? _PendingAmountList[0] : new PendAmount();
                            reader.NextResult();

                            var _TodayAmountList = _IEHDbContext.DataReaderMapToList<TodayAmount>(reader).ToList();
                            result.TdyAmount = _TodayAmountList != null && _TodayAmountList.Count != 0 ? _TodayAmountList[0] : new TodayAmount();
                            reader.NextResult();
                        }
                    }
                    return result;
                }
                finally
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AuditApi(AuditLogVM auditLogVM)
        {
            SqlParameter[] parameters = {
                 new SqlParameter("@Method",auditLogVM.Method),
                 new SqlParameter("@Endpoint",auditLogVM.Endpoint),
                 new SqlParameter("@Payload",auditLogVM.Payload),
                 new SqlParameter("@Response",auditLogVM.Response),
                 new SqlParameter("@CreatedBy",auditLogVM.CreatedBy),
                 new SqlParameter("@CreatedOn",auditLogVM.CreatedOn)
            };
            System.Data.Common.DbConnection connection = _IEHDbContext.GetDbConnection();
            try
            {
                if (connection.State == ConnectionState.Closed) { connection.Open(); }
                using (System.Data.Common.DbCommand cmd = connection.CreateCommand())
                {
                    _IEHDbContext.AddParametersToDbCommand(SpConstants.AuditApiLog, parameters, cmd);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
