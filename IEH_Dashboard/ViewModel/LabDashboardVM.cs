using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEH_Dashboard.ViewModel
{
    public class LabDashboardVM
    {
        public long UsersCreatedInLab { get; set; }
        public long ViewLabProfile { get; set; }
        public long ReceivedOrdersToday { get; set; }
        public long ApprovedOrdersToday { get; set; }
        public long CancelledOrdersToday { get; set; }
        public long OrdersForMonthInfographic { get; set; }

        public LabProfileVM LabProfile { get; set; }
        public OrdersByCurrentMonth OrdersByCurrentMonth { get; set; }
        public List<LabCustomersVM> LabCustomers { get; set; }
    }
}
