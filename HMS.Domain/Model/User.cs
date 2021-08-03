using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Domain.Model
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int UserType { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Password { get; set; }

    }
}
