using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Domain
{
   public class ClientBankDetail:BaseEntity
    {
        
        public string AccountName { get; set; }
        public int AccountNumber { get; set; }
        public string BankName { get; set; }
        public string IfscCode { get; set; }
        public string Address { get; set; }

    }
}
