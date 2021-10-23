using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Domain
{
public class OrderTable :BaseEntity
    {
        public int TableId { get; set; }
        public int OrderId { get; set; }
    }
}