using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project8.Models.Data
{
    public class Order_Ajax
    {
        public int OrderID { get; set; }

        
        public DateTime DateStart { get; set; }

        
        public DateTime DateEnd { get; set; }

        
        public bool OrderStatus { get; set; }

        public int CustomerID { get; set; }
        public int? Payment { get; set; }
        public int? Tracking { get; set; }
    }
}