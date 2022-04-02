using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Domain.Model
{
    public class UserSettings 
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Theme { get; set; }
        public int MenuDisplay { get; set; }
        public int BillWithGST { get; set; }
        public int BillWithCustomer { get; set; }
        public int BillWithLOGO { get; set; }
        public int BillWithSign { get; set; }
        public int BillWithSeal { get; set; }

        public string Language { get; set; }
    }
}
