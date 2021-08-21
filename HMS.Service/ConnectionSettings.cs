using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Service
{
   public class ConnectionSettings
    {
        public string DefaultConnection { get; set; }
    }

    public class Documents
    {
        public string Url { get; set; }
    }

    public class AWS
    {
        public string AccessId { get; set; }
        public string AccessKey { get; set; }
    }
}
