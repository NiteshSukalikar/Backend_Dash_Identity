using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEH_Dashboard.ViewModel
{
    public class ProviderDashboardDetailsVM
    {
        public UserViewModel UserDetails { get; set; }
        public List<UpcommingAppointment> CancelledAppointment { get; set; }
        public List<UpcommingAppointment> UpcommingAppointment { get; set; }
        public List<UpcommingAppointment> TodayAppointment { get; set; }
        public List<MessageViewModel> Messages { get; set; }

        public CompleteAmount CmpAmount { get; set; }
        public TodayAmount TdyAmount { get; set; }

        public PendAmount PndAmount { get; set; }
    }
}
