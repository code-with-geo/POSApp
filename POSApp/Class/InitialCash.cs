﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSApp.Class
{
    public class InitialCash
    {
        public int Id { get; set; }
        public int DrawerId { get; set; }
        public decimal Cash { get; set; }
        public string Remarks { get; set; }
        public int IsAdditional { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
