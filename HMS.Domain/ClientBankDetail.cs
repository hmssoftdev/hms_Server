using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Domain
{
   public class ClientBankDetail:BaseEntity
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public int AccountNumber { get; set; }
        public string BankName { get; set; }
        public string IfscCode { get; set; }
        public string Address { get; set; }

    }
}
