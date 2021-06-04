using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Domain.Model
{
   public class ClientBankDetail
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public int AccountName { get; set; }
        public string BankName { get; set; }
        public string IfscCode { get; set; }
        public string Address { get; set; }
    }
}
