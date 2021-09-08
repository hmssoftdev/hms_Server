namespace HMS.Domain.Model
{
    public class DishOrder
    {
        public int Id { get; set; }
        public float DeliveryTotal { get; set; }
        public float GrossTotal { get; set; }
        public int ItemCount { get; set; }
        public float ItemTotal { get; set; }
        public int AdminId { get; set; }
        public int UserId { get; set; }
        public int DeliveryOptionId { get; set; }
        public int PaymentMode { get; set; }
       
    }
}
