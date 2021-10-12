using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEH_Dashboard.ViewModel
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Subject { get; set; }

        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
