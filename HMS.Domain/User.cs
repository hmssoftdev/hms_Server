using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Domain
{
    public class User: BaseEntity
    {
        public string Name { get; set; }
        public int UserType { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Password { get; set; }

    }
}
