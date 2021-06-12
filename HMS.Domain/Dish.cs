using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Domain
{
    public class Dish : BaseEntity
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public int HalfPrice { get; set; }
        public int FullPrice { get; set; }

        public int HotelId { get; set; }
        public  Hotel Hotel{get; set;}
        public int MainCategoryId { get; set; }
        public bool IsVeg { get; set; }
        public bool IsHalf { get; set; }
        public bool IsFull { get; set; }
     

    }
}
