using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Domain
{
  public  class CityMaster:BaseEntity
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }
    }
}
