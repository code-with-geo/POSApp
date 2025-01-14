using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSApp.Class
{
    public class CashDrawer
    {
        public int Id { get; set; }
        public int DrawerId { get; set; }
        public int UserId { get; set; }
        public decimal InitialCash { get; set; }
        public decimal Withdrawals { get; set; }
        public decimal Expenses { get; set; }
        public decimal DrawerCash { get; set; }
        public DateTime? TimeStart { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
