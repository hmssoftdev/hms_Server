using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Domain
{
    public class OrderSummary
    {
        public int TotalBill { get; set; }
        public int TotalAmount { get; set; }
        public int DeliveryOptionId { get; set; }
    }
}
