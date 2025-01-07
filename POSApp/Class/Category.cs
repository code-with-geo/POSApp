﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSApp.Class
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
