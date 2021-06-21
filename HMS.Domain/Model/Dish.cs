using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Domain.Model
{
    public class Dish
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int HalfPrice { get; set; }
        public int FullPrice { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public int MainCategoryId { get; set; }
        public bool IsVeg { get; set; }
        public int Quantity { get; set; }
        public int TimeForCook { get; set; }
        public string NonVegCategory { get; set; }
        public string status { get; set; }
        public string ImageUrl { get; set; }


    }
}
