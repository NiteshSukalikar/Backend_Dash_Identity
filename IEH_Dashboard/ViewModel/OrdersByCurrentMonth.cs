using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEH_Dashboard.ViewModel
{
    public class OrdersByCurrentMonth
    {
        public long ReceivedOrders { get; set; }
        public long InprogressOrders { get; set; }
        public long FulfilledOrders { get; set; }
    }
}
