using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Domain.Model
{
  public  class DishCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int HotelId { get; set; }

        public Hotel Hotel { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
