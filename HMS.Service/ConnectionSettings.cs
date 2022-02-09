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
    public class AppSettings
    {
        public string Secret { get; set; }
        public string EmailFrom { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPass { get; set; }
    }
}
