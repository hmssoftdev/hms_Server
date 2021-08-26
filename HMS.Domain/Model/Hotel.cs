using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Domain.Model
{
  public  class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Seat { get; set; }
        public bool IsAc { get; set; }
        public string Shape { get; set; }
        public string BarcodeTest { get; set; }
    }
}
