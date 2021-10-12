using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEH_Dashboard.ViewModel
{
    public class MessageVM
    {
        public long Id { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public string CreatedByName { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
