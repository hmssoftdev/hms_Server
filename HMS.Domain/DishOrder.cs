using System.Collections.Generic;

namespace HMS.Domain
{
    public class DishOrder:BaseEntity
    {
        public float DeliveryTotal { get; set; }
        public float GrossTotal { get; set; }
        public int ItemCount { get; set; }
        public float ItemTotal { get; set; }
        public int AdminId { get; set; }
        public int UserId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public List<OrderStatus> OrderStatus{ get; set; }

    }
}
