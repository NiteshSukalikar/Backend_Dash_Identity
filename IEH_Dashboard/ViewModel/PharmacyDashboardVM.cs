using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEH_Dashboard.ViewModel
{
    public class PharmacyDashboardVM
    {
        public PharmacyDetailsVM PharmacyDetails { get; set; }
        public long IncomingOrderCount { get; set; }
        public long InprogressCount { get; set; }
        public long DeliveredCount { get; set; }
        public long PaidOrders { get; set; }
        public long PendingPayments { get; set; }
        public List<MessageVM> Messages { get; set; }
    }
}
