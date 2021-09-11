using System;

namespace HMS.Domain.Model
{
    public class OrderStatus 
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Stutus { get; set; }

    
        public DateTime CreatedOn { get; set; } 
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
    }
}
