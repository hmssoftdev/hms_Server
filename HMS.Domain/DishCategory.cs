using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Domain
{
   public class DishCategory : BaseEntity
    {
        public string Name { get; set; }

        public int HotelId { get; set; }

        public Hotel Hotel { get; set; }
        public int gstCompliance { get; set; }
    }
}
