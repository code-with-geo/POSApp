using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSApp.Class
{
    public class Locations
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
