using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Domain
{
   public class Admin:BaseEntity
    {
       
        public string BusinessName { get; set; }
        public string Category { get; set; }
        public int FoodLincNum { get; set; }
        public string Address { get; set; }
        public int Gst { get; set; }
        public ClientBankDetail BankDetail { get; set; }
        public int PinCode { get; set; }
        public string RestaurentLogo { get; set; }
        public string RestaurentSeal { get; set; }
        public string Signature { get; set; }
        public string TermAndCondition { get; set; }
    }
}
