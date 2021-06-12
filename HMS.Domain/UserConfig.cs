using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Domain
{
   public class UserConfig:BaseEntity
    {
        
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int City { get; set; }
        public int State { get; set; }
        public long PinCode { get; set; }
    }
}
